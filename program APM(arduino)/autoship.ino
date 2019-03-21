 
#include <TaskScheduler.h>
//====================IMU inisialiasi=======================

#include <SPI.h>
#include <math.h>

#define ToD(x) (x/131)
#define ToG(x) (x*9.80665/16384)
#define samplingInterval 20
#define xAxis 0
#define yAxis 1
#define zAxis 2

#define Aoffset 0.8
//#include <DS3231.h>

// Init the DS3231 using the hardware interface
//DS3231  rtc(SDA, SCL);
int time=0;
int time_old=0;

const int ChipSelPin1 = 53;

float angle=0;
float angleX=0;
float angleY=0;
float angleZ=0;
float ADegX,ADegY,ADegZ;
//======================COMPAS INISIALISASI====================
#include <Wire.h> //I2C Arduino Library
#define Magnetometer_mX0 0x03  
#define Magnetometer_mX1 0x04  
#define Magnetometer_mZ0 0x05  
#define Magnetometer_mZ1 0x06  
#define Magnetometer_mY0 0x07  
#define Magnetometer_mY1 0x08  
int mX0, mX1, mX_out;
int mY0, mY1, mY_out;
int mZ0, mZ1, mZ_out;
float heading, headingDegrees, headingFiltered, declination;
float Xm,Ym,Zm;
#define Magnetometer 0x1E //I2C 7bit address of HMC5883
//====================GPS INISIALISASI=====================
//#include <waypointClass.h> 
float turnDirection;
class  waypointClass
{
    
  public:
    waypointClass(float pLong = 0, float pLat = 0)
      {
        fLong = pLong;
        fLat = pLat;
      }
      
    float getLat(void) {return fLat;}
    float getLong(void) {return fLong;}

  private:
    float fLong, fLat;
      
  
};  // waypointClass

//=========================================================
String dataIn;
String dt[10];
char header[]="GNGGA";
int i;
boolean parsing=false;
double kecmotor1,kecmotor2,kecmotor3,kecmotor4;
int Xkey=93,Ykey=100,Ximg,Yimg,mode=7;

float currentLat,
      currentLong,
      targetLat,
      targetLong;
int distanceToTarget,            // current distance to target (current waypoint)
    originalDistanceToTarget;    // distance to original waypoing when we started navigating to it
char kutub[5];
char kutub1[5];
// Compass navigation
int targetHeading;              // where we want to go to reach current waypoint
int currentHeading;             // where we are actually facing now
int headingError;               // signed (+/-) difference between targetHeading and currentHeading
#define HEADING_TOLERANCE 5     // tolerance +/- (in degrees) within which we don't attempt to turn to intercept targetHeading
// Waypoints===================================================
#define WAYPOINT_DIST_TOLERANE  5   // tolerance in meters to waypoint; once within this tolerance, will advance to the next waypoint
#define NUMBER_WAYPOINTS 5          // enter the numebr of way points here (will run from 0 to (n-1))
int waypointNumber = -1;            // current waypoint number; will run from 0 to (NUMBER_WAYPOINTS -1); start at -1 and gets initialized during setup()
waypointClass waypointList[NUMBER_WAYPOINTS] = {waypointClass(-7.275579, 112.793929), waypointClass(-7.275579, 112.793929), waypointClass(-7.275579, 112.793929), waypointClass(-7.275579, 112.793929), waypointClass(-7.275579, 112.793929) };

//=========================sensor suhu====================
#include <OneWire.h>
OneWire  ds(A2);  // on pin 10 (a 4.7K resistor is necessary)

#define analogInPin2  A1  // Analog input pin 1

#define analogInPin1  A0  // Analog input pin 2
int sensorValue; //adc value
float outputValueConductivity; //conductivity value
float outputValueTDS; //TDS value


  float celsius, fahrenheit;
  float rata, hasil, rata2, hasil2, sensor, sensor2;
//motor

int IN_1=12;
int IN_2=11;
int IN_3=8;
char motorON=0;
char motorFF=0;
//===================== Callback methods prototypes========

void t1Callback();
void t2Callback();
void t3Callback();
void t4Callback();
void t5Callback();
void t6Callback();

//Tasks
//Task t4();
Task t1(1, TASK_FOREVER, &t1Callback);
Task t2(1, TASK_FOREVER, &t2Callback);
Task t3(1, TASK_FOREVER, &t3Callback);
Task t4(1, TASK_FOREVER, &t4Callback);
Task t5(1, TASK_FOREVER, &t5Callback);
Task t6(1, TASK_FOREVER, &t6Callback);
Scheduler runner;



void loop () {
  int i;
  
  runner.execute();
  i++;
}
//===============================gps interuupt===========
void serialgps()
{
 
   if(Serial1.available()>0) {
    char inChar = (char)Serial1.read();
    dataIn += inChar;
    if (inChar == '\n') {  
  // Serial.println(dataIn);
         
    if((dataIn[4]==header[3])&&((dataIn[5]==header[4])))
    {
      parsing = true;

    }
    else
    {dataIn="";
      }
    
  }
  }
 
if(parsing){
    parsingData();
    parsing=false;
    dataIn="";
  }
}



