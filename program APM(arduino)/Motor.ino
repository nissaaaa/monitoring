//mendefinisikan pin yang digunakan untuk control pin
//int IN_1 = 4;
//int IN_2 = 5;


 
void t6Callback()
{
 //Putar Mesin searah jarum jam
 processmotor();
 
 
}
void processmotor(){
  motorON=Serial.read();
  motorFF=Serial.read();
if (motorON == 100){
 digitalWrite(IN_1, HIGH);
 digitalWrite(IN_2, LOW);
 analogWrite (IN_3, 150);
 Serial.print("ok");
 delay(2000);
 }

if (motorFF ==200){
 digitalWrite(IN_1, LOW);
 digitalWrite(IN_2, HIGH);
 analogWrite (IN_3, 150);
 Serial.print("y");
 delay(2000);

 }
  
}

