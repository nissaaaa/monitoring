void t1Callback() {
  //Serial.print("Acc X ");
  //Serial.print(AcceX(ChipSelPin1));
  //Serial.print(AcceDeg(ChipSelPin1,0));
  //Serial.print("   ");
  //Serial.print("Acc Y ");
  //Serial.print(AcceY(ChipSelPin1));
  //Serial.print(AcceDeg(ChipSelPin1,1));
  //Serial.print("   ");
  //Serial.print("Acc Z ");  
  AcceDeg(ChipSelPin1,0);
  AcceDeg(ChipSelPin1,1);
  AcceDeg(ChipSelPin1,2);
  //Serial.println(AcceZ(ChipSelPin1));

  
  
}

//=============================FUNGSI IMUUU===================
void SPIwrite(byte reg, byte data, int ChipSelPin) {
  uint8_t dump;
  digitalWrite(ChipSelPin,LOW);
  dump=SPI.transfer(reg);
  dump=SPI.transfer(data);
  digitalWrite(ChipSelPin,HIGH);
}


uint8_t SPIread(byte reg,int ChipSelPin) {
  uint8_t dump;
  uint8_t return_value;
  uint8_t addr=reg|0x80;
  digitalWrite(ChipSelPin,LOW);
  dump=SPI.transfer(addr);
  return_value=SPI.transfer(0x00);
  digitalWrite(ChipSelPin,HIGH);
  return(return_value);
}


int AcceX(int ChipSelPin) {
  uint8_t AcceX_H=SPIread(0x3B,ChipSelPin);
  uint8_t AcceX_L=SPIread(0x3C,ChipSelPin);
  int16_t AcceX=AcceX_H<<8|AcceX_L;
  return(AcceX);
}


int AcceY(int ChipSelPin) {
  uint8_t AcceY_H=SPIread(0x3D,ChipSelPin);
  uint8_t AcceY_L=SPIread(0x3E,ChipSelPin);
  int16_t AcceY=AcceY_H<<8|AcceY_L;
  return(AcceY);
}


int AcceZ(int ChipSelPin) {
  uint8_t AcceZ_H=SPIread(0x3F,ChipSelPin);
  uint8_t AcceZ_L=SPIread(0x40,ChipSelPin);
  int16_t AcceZ=AcceZ_H<<8|AcceZ_L;
  return(AcceZ);
}


int GyroX(int ChipSelPin) {
  uint8_t GyroX_H=SPIread(0x43,ChipSelPin);
  uint8_t GyroX_L=SPIread(0x44,ChipSelPin);
  int16_t GyroX=GyroX_H<<8|GyroX_L;
  return(GyroX);
}


int GyroY(int ChipSelPin) {
  uint8_t GyroY_H=SPIread(0x45,ChipSelPin);
  uint8_t GyroY_L=SPIread(0x46,ChipSelPin);
  int16_t GyroY=GyroY_H<<8|GyroY_L;
  return(GyroY);
}


int GyroZ(int ChipSelPin) {
  uint8_t GyroZ_H=SPIread(0x47,ChipSelPin);
  uint8_t GyroZ_L=SPIread(0x48,ChipSelPin);
  int16_t GyroZ=GyroZ_H<<8|GyroZ_L;
  return(GyroZ);
}


//--- Function to obtain angles based on accelerometer readings ---//
float AcceDeg(int ChipSelPin,int AxisSelect) {
  float Ax=ToG(AcceX(ChipSelPin));
  float Ay=ToG(AcceY(ChipSelPin));
  float Az=ToG(AcceZ(ChipSelPin));
  ADegX=((atan(Ax/(sqrt((Ay*Ay)+(Az*Az)))))/PI)*180;
  ADegY=((atan(Ay/(sqrt((Ax*Ax)+(Az*Az)))))/PI)*180;
  ADegZ=((atan((sqrt((Ax*Ax)+(Ay*Ay)))/Az))/PI)*180;
  switch (AxisSelect)
  {
    case 0:
    return ADegX;
    break;
    case 1:
    return ADegY;
    break;
    case 2:
    return ADegZ;
    break;
  }
}


//--- Function to obtain angles based on gyroscope readings ---//
float GyroDeg(int ChipSelPin, int AxisSelect) {
  time_old=time;
  time=millis();
  float dt=time-time_old;
  if (dt>=1000)
  {
    dt=0;
  }
  float Gx=ToD(GyroX(ChipSelPin));
  if (Gx>0 && Gx<1.4)
  {
    Gx=0;
  }
  float Gy=ToD(GyroY(ChipSelPin));
  float Gz=ToD(GyroZ(ChipSelPin));
  angleX+=Gx*(dt/1000);
  angleY+=Gy*(dt/1000);
  angleZ+=Gz*(dt/1000);
  switch (AxisSelect)
  {
    case 0:
    return angleX;
    break;
    case 1:
    return angleY;
    break;
    case 2:
    return angleZ;
    break;
  }
}


void ConfigureMPU6000()
{
  // DEVICE_RESET @ PWR_MGMT_1, reset device
  SPIwrite(0x6B,0x80,ChipSelPin1);
  delay(150);

  // TEMP_DIS @ PWR_MGMT_1, wake device and select GyroZ clock
  SPIwrite(0x6B,0x03,ChipSelPin1);
  delay(150);

  // I2C_IF_DIS @ USER_CTRL, disable I2C interface
  SPIwrite(0x6A,0x10,ChipSelPin1);
  delay(150);

  // SMPRT_DIV @ SMPRT_DIV, sample rate at 1000Hz
  SPIwrite(0x19,0x00,ChipSelPin1);
  delay(150);

  // DLPF_CFG @ CONFIG, digital low pass filter at 42Hz
  SPIwrite(0x1A,0x03,ChipSelPin1);
  delay(150);

  // FS_SEL @ GYRO_CONFIG, gyro scale at 250dps
  SPIwrite(0x1B,0x00,ChipSelPin1);
  delay(150);

  // AFS_SEL @ ACCEL_CONFIG, accel scale at 2g (1g=8192)
  SPIwrite(0x1C,0x00,ChipSelPin1);
  delay(150);
}

