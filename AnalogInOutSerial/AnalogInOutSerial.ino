/*
  Analog input, analog output, serial output

  Reads an analog input pin, maps the result to a range from 0 to 255 and uses
  the result to set the pulse width modulation (PWM) of an output pin.
  Also prints the results to the Serial Monitor.

  The circuit:
  - potentiometer connected to analog pin 0.
    Center pin of the potentiometer goes to the analog pin.
    side pins of the potentiometer go to +5V and ground
  - LED connected from digital pin 9 to ground through 220 ohm resistor

  created 29 Dec. 2008
  modified 9 Apr 2012
  by Tom Igoe

  This example code is in the public domain.

  https://www.arduino.cc/en/Tutorial/BuiltInExamples/AnalogInOutSerial
*/

// These constants won't change. They're used to give names to the pins used:
const int analogInPin = A0;  // Analog input pin that the potentiometer is attached to
const int analogOutPin = 9; // Analog output pin that the LED is attached to

void setup() {
  // initialize serial communications at 9600 bps:
  Serial.begin(9600);
}

void loop() {

  
  int sns0=rand() % 8999 + 1000 ;
  int sns1=rand() % 8999 + 1000 ;
  int sns2=rand() % 8999 + 1000 ;
  int sns3=rand() % 8999 + 1000 ;
  int sns4=rand() % 8999 + 1000 ;
  int sns5=rand() % 8999 + 1000 ;
  int sns6=rand() % 8999 + 1000 ;
  int sns7=rand() % 8999 + 1000 ;
  int sns8=rand() % 8999 + 1000 ;

  int swtch0=rand() % 2 ;
  int swtch1=rand() % 2 ;
  int swtch2=rand() % 2 ;
  int swtch3=rand() % 2 ;
  int swtch4=rand() % 2 ;
  int swtch5=rand() % 2 ;
  int swtch6=rand() % 2 ;
  int swtch7=rand() % 2 ;


  // print the results to the Serial Monitor:
  
  Serial.print("$");
  Serial.print(sns0);  
  Serial.print(sns1);
  Serial.print(sns2);
  Serial.print(sns3);
  Serial.print(sns4);
  Serial.print(sns5);
  Serial.print(sns6);
  Serial.print(sns7);
  Serial.print(sns8);

  Serial.print(swtch0);
  Serial.print(swtch1);
  Serial.print(swtch2);
  Serial.print(swtch3);
  Serial.print(swtch4);
  Serial.print(swtch5);
  Serial.print(swtch6);
  Serial.println(swtch7);

  //Serial.println(outputValue);

  // wait 2 milliseconds before the next loop for the analog-to-digital
  // converter to settle after the last reading:
  delay(50);
}
