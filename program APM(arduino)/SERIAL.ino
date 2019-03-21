
void t4Callback() {
//Serial.print("YPR::");
//Serial.print(headingFiltered);
//Serial.print(",");
//Serial.print(ADegX);
//Serial.print(","); 
//Serial.print(ADegY);
//Serial.print(","+dt[1]+","+dt[2]+","+dt[3]+","+dt[4]);
//Serial.print(",");
//Serial.print(celsius);
//Serial.print(",");
//Serial.print((float)(currentLat),6);
//Serial.print(",");
//Serial.print((float)(currentLong),6);
//Serial.print(",");
//Serial.print(distanceToTarget);
//Serial.print(",");
//Serial.print(rata);
///Serial.print(",");
//Serial.println(turnDirection);
//int milis=millis();
 
//int milis2=milis%1000;
//int mdetik=(milis2*1000)%1000;
if (Serial2.read()=='A'){
 Serial.print("ok");
 digitalWrite(IN_1, HIGH);
  digitalWrite(IN_2, LOW);
analogWrite(IN_3, 50);
 }

if (Serial2.read()=='B'){
 Serial.print("y");
  digitalWrite(IN_1, LOW);
  digitalWrite(IN_2, HIGH);
analogWrite(IN_3, 50);


 }
 if (Serial2.read()=='C'){
analogWrite(IN_3, 0);
 }

 if (Serial.read()=='A'){
 Serial.print("ok");
 digitalWrite(IN_1, HIGH);
  digitalWrite(IN_2, LOW);
analogWrite(IN_3, 100);
 }

if (Serial.read()=='B'){
 Serial.print("y");
  digitalWrite(IN_1, LOW);
  digitalWrite(IN_2, HIGH);
analogWrite(IN_3, 100);


 }
 if (Serial.read()=='C'){
analogWrite(IN_3, 0);
 }
 static unsigned long samplingTime = millis();
 // static unsigned long printTime = millis();

  if(millis()-samplingTime > samplingInterval)
  {
//Time  t;
 //t = rtc.getTime();
////////////////////////////////////
//water suhu ph do bat long lat i rtc.getTimeStr()
Serial2.print("WATER");
//Serial2.print(" ");
//Serial2.print(0.5);
Serial2.print(" ");
Serial2.print(celsius);
Serial2.print(" ");
Serial2.print(rata);
Serial2.print(" ");
Serial2.print(outputValueConductivity);
Serial2.print(" ");
Serial2.print(outputValueTDS);
Serial2.print(" ");
Serial2.print((float)(currentLat),6);
Serial2.print(" ");
//Serial2.print(milis2);
//Serial2.print(" ");
Serial2.println((float)(currentLong),6);

delay(1500);

//Time  t;
 //t = rtc.getTime();
////////////////////////////////////
//water suhu ph do bat long lat i rtc.getTimeStr()
Serial.print("WATER");
//Serial.print(" ");
//Serial.print(0.5);
Serial.print(" ");
Serial.print(celsius);
Serial.print(" ");
Serial.print(rata);
Serial.print(" ");
Serial.print(outputValueConductivity);
Serial.print(" ");
Serial.print(outputValueTDS);
Serial.print(" ");
Serial.print((float)(currentLat),6);
Serial.print(" ");
//Serial.print(milis2);
//Serial.print(" ");
Serial.println((float)(currentLong),6);
Serial.println(millis());
Serial.print(samplingTime);

delay(1500);
  }

}





