void t3Callback() {
   processGPS();
   calcDesiredTurn();                // calculate how we would optimatally turn, without regard to obstacles      
  //distanceToTarget; // ini buat jaraknya
  //turnDirection; //  ini buat error sudutnya
}
//======================FUNGSI GPS=========================
void parsingData(){
int j=0;
 
 
//inisialisasi variabel, (reset isi variabel)
dt[j]="";
//proses parsing data
for(i=7;i<dataIn.length();i++){
//pengecekan tiap karakter dengan karakter (#) dan (,)
if ((dataIn[i] == ','))
{
//increment variabel j, digunakan untuk merubah index array penampung
j++;
dt[j]="";       //inisialisasi variabel array dt[j]
}
else
{
//proses tampung data saat pengecekan karakter selesai.
dt[j] = dt[j] + dataIn[i];
}
}
  kecmotor1=dt[1].toFloat();
  kecmotor2=dt[2].toFloat();
  kecmotor3=dt[3].toFloat();
  kecmotor4=dt[4].toFloat();
//  Serial.println(dt[1]+","+dt[2]+","+dt[3]+","+dt[4]);
  processGPS();
 }

 void processGPS(void)
{
  currentLat = convertDegMinToDecDeg(dt[1].toFloat());
  currentLong = convertDegMinToDecDeg(dt[3].toFloat());
       dt[2].toCharArray(kutub, 5);
        dt[4].toCharArray(kutub1, 5);     
  if (kutub[0] == 'S')            // make them signed
    currentLat = -currentLat;
  if (kutub1[1] == 'W')  
    currentLong = -currentLong; 
             
  // update the course and distance to waypoint based on our new position
  distanceToWaypoint();
  courseToWaypoint();         
  
} 

// converts lat/long from Adafruit degree-minute format to decimal-degrees; requires <math.h> library
double convertDegMinToDecDeg (float degMin) 
{
  double min = 0.0;
  double decDeg = 0.0;
 
  //get the minutes, fmod() requires double
  min = fmod((double)degMin, 100.0);
 
  //rebuild coordinates in decimal degrees
  degMin = (int) ( degMin / 100 );
  decDeg = degMin + ( min / 60 );
 
  return decDeg;
}

int distanceToWaypoint() 
{
  
  float delta = radians(currentLong - targetLong);
  float sdlong = sin(delta);
  float cdlong = cos(delta);
  float lat1 = radians(currentLat);
  float lat2 = radians(targetLat);
  float slat1 = sin(lat1);
  float clat1 = cos(lat1);
  float slat2 = sin(lat2);
  float clat2 = cos(lat2);
  delta = (clat1 * slat2) - (slat1 * clat2 * cdlong); 
  delta = sq(delta); 
  delta += sq(clat2 * sdlong); 
  delta = sqrt(delta); 
  float denom = (slat1 * slat2) + (clat1 * clat2 * cdlong); 
  delta = atan2(delta, denom); 
  distanceToTarget =  delta * 6372795; 
//========================GURUNG==================================   
  // check to see if we have reached the current waypoint
 if (distanceToTarget <= WAYPOINT_DIST_TOLERANE)
    nextWaypoint();
    
  return distanceToTarget;
}  // distanceToWaypoint()

//=========================COURSE==================

// returns course in degrees (North=0, West=270) from position 1 to position 2,
// both specified as signed decimal-degrees latitude and longitude.
// Because Earth is no exact sphere, calculated course may be off by a tiny fraction.
// copied from TinyGPS library
int courseToWaypoint() 
{
  float dlon = radians(targetLong-currentLong);
  float cLat = radians(currentLat);
  float tLat = radians(targetLat);
  float a1 = sin(dlon) * cos(tLat);
  float a2 = sin(cLat) * cos(tLat) * cos(dlon);
  a2 = cos(cLat) * sin(tLat) - a2;
  a2 = atan2(a1, a2);
  if (a2 < 0.0)
  {
    a2 += TWO_PI;
  }
  targetHeading = degrees(a2);
  return targetHeading;
}   // courseToWaypoint()

//=======================NEXT WAYPOINT===============
void nextWaypoint(void)
{
  waypointNumber++;
  targetLong = waypointList[waypointNumber].getLat();
  targetLat = waypointList[waypointNumber].getLong();
  
  if ((targetLat == 0 && targetLong == 0) || waypointNumber >= NUMBER_WAYPOINTS)    // last waypoint reached? 
    {
//      driveMotor->run(RELEASE);    // make sure we stop
//      turnMotor->run(RELEASE);  
    //  lcd.clear();
    //  lcd.println(F("* LAST WAYPOINT *"));
//      loopForever();
    }
    
   processGPS();
   distanceToTarget = originalDistanceToTarget = distanceToWaypoint();
   courseToWaypoint();
   
}  // nextWaypoint()
//============================================
void calcDesiredTurn(void)
{
    // calculate where we need to turn to head to destination
    headingError = targetHeading - currentHeading;
    
    // adjust for compass wrap
    if (headingError < -180)      
      headingError += 360;
    if (headingError > 180)
      headingError -= 360;
  
      turnDirection = headingError;
      //return turnDirection ;
}  // calcDesiredTurn()




