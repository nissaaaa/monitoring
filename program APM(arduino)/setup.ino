void setup () {

  //========================Setup IMUUUUU===================
  
  Serial.begin(9600);  
  Serial1.begin(9600);
   Serial2.begin(9600);
  //As per APM standard code, stop the barometer from holding the SPI bus
  pinMode(40, OUTPUT);
  digitalWrite(40, HIGH);
   pinMode(IN_1, OUTPUT);
   pinMode(IN_2, OUTPUT);
   pinMode(IN_3, OUTPUT);


  SPI.begin();  
  SPI.setClockDivider(SPI_CLOCK_DIV16); 


  SPI.setBitOrder(MSBFIRST); 
  SPI.setDataMode(SPI_MODE0);
  delay(100);
  
  pinMode(ChipSelPin1, OUTPUT);

  ConfigureMPU6000();  // configure chip
  //========================COMPAS SETUP====================
   Wire.begin();
//   rtc.begin();
//  rtc.setTime(11 ,45 ,35);  
 
 
  Wire.beginTransmission(Magnetometer); 
  Wire.write(0x02); // Select mode register
  Wire.write(0x00); // Continuous measurement mode
  Wire.endTransmission();
  //======================GPS SETUP===========================
  //===================interupt pin====================
  attachInterrupt(4, serialgps, CHANGE);
  dataIn="";
  //===================================================
  runner.init();
  runner.addTask(t1);
  runner.addTask(t2);
  runner.addTask(t3);
  runner.addTask(t4);
  runner.addTask(t5);
  runner.addTask(t6);

  t1.enable();
  t2.enable();
  t3.enable();
  t4.enable();
  t5.enable();
  t6.enable();
}
