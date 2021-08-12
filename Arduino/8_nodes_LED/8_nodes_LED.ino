#define LEDPin6    6 //Power button #1
#define LEDPin7    7 //Power button #2
#define LEDPin8    8 //Power button #3
#define LEDPin9    9 //Power button #4
#define LEDPin4    4 //Power button #5
#define LEDPin12    12 //Power button #6
#define LEDPin11    11 //Power button #7
#define LEDPin10    10 //Power button #8

//byte i = 12;
byte a = 12;
//byte b = 12;
void setup() 
{
  ////put your setup code here, to run once:
  /*for(i=12; i>3; i--)
  pinMode(i, OUTPUT);*/
  for(a=10; a>7; a--)
  pinMode(a, OUTPUT);
  /*for(b=8; b>2; b--)
  pinMode(b, OUTPUT);*/
}

void loop() 
{
  ////put your main code here, to run repeatedly:
  /*for(i=12; i>3; i--)
  digitalWrite(i,HIGH);
  delay(500);
  for(i=12; i>3; i--)
  digitalWrite(i,LOW);
  delay(500);
  */
  for(a=10; a>7; a--)
  digitalWrite(a,HIGH);
  delay(1000);
  for(a=10; a>7; a--)
  digitalWrite(a,LOW);
  delay(1000);
  /*for(b=8; b>2; b--)
  digitalWrite(b,HIGH);
  delay(500);
  for(b=8; b>2; b--)
  digitalWrite(b,LOW);
  delay(500);*/
}
