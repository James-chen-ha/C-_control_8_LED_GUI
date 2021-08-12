const int LED[] = {6,7,8,9,4,12,11,10};//LED腳位
//String inputString = "";         // a String to hold incoming data
bool stringComplete = false;  // whether the string is complete(字串是否完整)//一開始為false 
byte receivedByteArray[9];//對應於C#的 byte[] sendByteArray = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0A };
int receiveIndex = 0;//接收指標=0
void setup() 
{
  for(int i=0; i<8; i++)//(0~7)
  {
    pinMode(LED[i], OUTPUT);
    digitalWrite(LED[i], LOW);//一開始皆不亮
  }
  // initialize serial:
  Serial.begin(9600);
  // reserve 200 bytes for the inputString:
  //inputString.reserve(200);
}

void loop() 
{
  // print the string when a newline arrives:
  if (stringComplete)//stringComplete=true
  {
    for(int i = 0; i < 8; i++)
    {
      if (receivedByteArray[i] == 1)//對應於C#的sendByteArray[1] = 0x01;
      {
        digitalWrite(LED[i], HIGH);
      }
      else//receivedByteArray[i] == 0//對應於C#的sendByteArray[1] = 0x00;
      {
        digitalWrite(LED[i], LOW);
      }
    }    
  }
}

void serialEvent()
{
    byte receiveByte = Serial.read();
    receivedByteArray[receiveIndex] = receiveByte;//對應於C#的 byte[] sendByteArray = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0A };//對應於上面的:byte receivedByteArray[9]
    //ex:receiveByteArray[0]=0x00(0=0+1=1)=receiveByte,receiveByteArray[1]=0x00,0x00(1=1+1=2).........(8=8+1=9)=>0x0A0換行
    receiveIndex = receiveIndex + 1;
    if (receiveByte == 0x0A) 
    {
      stringComplete = true;//等於true的話，開始跑loop
      receiveIndex = 0;//清除，然後從下一個開始收
    }
}
