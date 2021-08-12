#include <Arduino.h>
#include <Ethernet.h>
#include <EthernetUdp.h>
#include <Wire.h>
#include <SPI.h>
#include <Adafruit_GFX.h>
#include <Adafruit_SSD1306.h>
#include "SdFat.h"
#include <SoftwareSerial.h>
#include "Timer.h"
#include <Fonts/FreeSans9pt7b.h>
#include "PCF8575.h"
#include <EEPROM.h>
#include "TimedAction.h"
#include "SCoop.h"

PCF8575 USBBox1(0x20); // Set i2c address
Timer t;
SdFat SD;
SoftwareSerial BT(A14, A15);
File sdFile;
SdFile file;
char *chArray;

int timerEvent;
int EthReturn = 1;
const int buzzerDetect = 49; // SW420 DIO
const int buzzerLED = 48;
const int ACOut[] = {A0, A1, A2, A3};
const int ACIn[] = {A8, A9, A10, A11};
const int analogIn[] = {A12, A13};
const int digitalIn[] = {2, 3};
const int relay[] = {24, 26, 28, 30, 32, 34, 36, 38, 39, 37, 35, 33, 31, 29, 27, 25};
const int WakeUpBtn = A7;
//const int SUTPwrOk[] = {52,53};
double XYZ1Loc[] = {0, 0, 0};
double XYZ2Loc[] = {0, 0, 0};
String loc;
int sendXYZbtnStep = 0;
boolean sendXYZCMD = false;
int IOState = 0;;
long buzzerOn = 0;
int KBMS_I2C_Addr = 1;
int KBMS_incomingByte=0;
char incomingByte = 0;
int boxStatus[4];

String strSer1 = "";
String strSer2 = "";

char RevCMD[200];       //透過UDP接收從console傳來的資料的陣列
char SendCMD[20];       //透過UDP發送資料到console的陣列
int SendCMDByte;        //多少byte要送到console
int COMIndex = 0;
char RevCMD2[200];      //記錄從LED box或XYZ table透過Com port傳來資料的陣列
int COMIndex2 = 0;
char incomingByte2 = 0;
int BtnTime[] = {0, 0};
char XYZ1[5][3];        //記錄XYZ box1的座標
char XYZ2[5][3];        //記錄XYZ box2的座票
int packetSize = 0;     //記錄從UDP傳來多少byte的資料
double moveStep = 0;    //記錄XYZ一次移動的距離長度是0.01、0.1或是1公分
int XYZReturn = 0;
String XYZRes;
String XYZCMD;
String proj;
boolean CMDFromBTorLan = false;   //記錄現在command是從BT傳來或是Lan
unsigned int localPort = 5901;   //監聽和發送port為5901
byte ip[] = {0, 0, 0, 0};
//byte mac[] = {  0xA8, 0x61, 0x0A, 0xAE, 0x75, 0x94};    //MAC for Box No.1
//byte mac[] = {  0xA8, 0x61, 0x0A, 0xAE, 0x48, 0x66};    //MAC for Box No.2
//byte mac[] = {  0xA8, 0x61, 0x0A, 0xAE, 0x48, 0x73};    //MAC for Box No.3
//byte mac[] = {  0xA8, 0x61, 0x0A, 0xAE, 0x48, 0xDA};    //MAC for Box No.4
byte mac[] = {  0xA8, 0x61, 0x0A, 0xAE, 0x5C, 0x69};    //MAC for Box No.5

boolean ser1Trans = false;
boolean ser2Trans = false;
boolean getIP = false;
boolean boxOccupy = false;
EthernetClient client;
unsigned long startTime = 0;
unsigned long currentTime = 0;
unsigned long OccupyStartTime = 0;
unsigned long OccupyCurrentTime = 0;
// buffers for receiving and sending data
char packetBuffer[UDP_TX_PACKET_MAX_SIZE];  // buffer to hold incoming packet,
// An EthernetUDP instance to let us send and receive packets over UDP
EthernetUDP Udp;

//OLED Setup
#define SCREEN_WIDTH 128 // OLED display width, in pixels
#define SCREEN_HEIGHT 32 // OLED display height, in pixels
#define OLED_RESET 4
Adafruit_SSD1306 display(SCREEN_WIDTH, SCREEN_HEIGHT, &Wire, OLED_RESET);

//螢幕設定，定義顯示高度跟寬度
#define LOGO16_GLCD_HEIGHT 16
#define LOGO16_GLCD_WIDTH  16



void(* resetFunc) (void) = 0;



void ReceiveUDP() {
  t.update();
  if (Ethernet.linkStatus() == 2)
  {
    if (getIP == true)
    {
      OLEDOn();
      getIP = false;
    }
  }
  else if (Ethernet.linkStatus() == 1)
  {
    if (getIP == false)
    {
      Ethernet.begin(mac);
      OLEDOn();
      getIP = true;
    }
  }

  if (digitalRead(WakeUpBtn) == HIGH)
  {
    OLEDOn();
  }

  if (BT.available()) //if the data is from Bluetooth
  {
    packetSize = 0;
    while (BT.available())
    {
      CMDFromBTorLan = true;   //Set transfer interface is Bluetooth
      RevCMD[packetSize] = BT.read();
      Serial.print(int(RevCMD[packetSize]));
      packetSize = packetSize + 1;
    }
    boxOccupy = true;
  }
  else  //if the data is from LAN
  {
    packetSize = Udp.parsePacket();
    if (packetSize != 0)
    {
      if (boxOccupy == false)
      {
        CMDFromBTorLan = false;  //Set transfer interface is LAN
        OccupyStartTime = millis();
        SendCMD[0] = (byte)112;
        OccupyCurrentTime = 0;
        Serial.print("Received byte size:");
        Serial.println(packetSize);
        Udp.read(RevCMD, packetSize);
        for (int i = 0; i < packetSize; i++)
        {
          Serial.print("Byte");
          Serial.print(i);
          Serial.print(":");
          Serial.println(int(RevCMD[i]));
        }
      }
      else
      {
        Serial.println("Received byte, but box is busy.");
        OccupyStartTime = millis();
        if (SendCMD[0] == (byte)112)
        {
          UDPSend(1);
        }
        else
        {
          ClrCMD();
          UDPSend(SendCMDByte);
          Serial.println(boxOccupy);
          packetSize = 0;
          ClrCMD();
          Serial.println(int(RevCMD[0]));
          boxOccupy = false;
        }
      }
    }
    else if (boxOccupy == true)
    {
      Serial.println("Box is busy, checking box status.");
      OccupyCurrentTime = millis();
      {
        if (OccupyCurrentTime - OccupyStartTime < 30000)
        {
          /*
            if(SendCMD[0]!=(byte)112)
            {
            UDPSend(SendCMDByte);
            boxOccupy = false;
            ClrCMD();
            }
          */
        }
        else
        {
          Serial.println("Occupy time over 30 seconds and no command received, release box occupy status.");
          SendCMD[0] = (byte)128;
          UDPSend(1);
          boxOccupy = false;
          ClrCMD();
          OccupyStartTime = 0;
          OccupyCurrentTime = 0;
        }
      }
    }
  }
}


void setup() {
  InitialBox();
}



void BoxControl() {
  if ((int)RevCMD[0] != 0)
  {
    switch ((int)RevCMD[0]) {
      case 1:
        if (boxOccupy == false)
        {
          boxOccupy = true;
          UDPSend(1);
          startTime = millis();
          if ((int)RevCMD[2] == 2)
          {
            digitalWrite(ACOut[(int)RevCMD[1] - 1], HIGH);
          }
          else if ((int)RevCMD[2] == 1)
          {
            digitalWrite(ACOut[(int)RevCMD[1] - 1], LOW);
          }
        }
        else
        {
          currentTime = millis();
          if (currentTime - startTime > 3000)
          {
            SendCMDByte = 2;
            SendCMD[0] = 0;
            SendCMD[1] = (int)digitalRead(ACIn[(int)RevCMD[1] - 1]) + 1;
            Serial.print("Control box action:");
            if (SendCMD[1] == 1)
            {
              Serial.println("AC Off");
            }
            else
            {
              Serial.println("AC On");
            }
            //UDPSend(2);
            //ClrCMD();
            //boxOccupy = false;
          }
        }

        break;




      case 2:   //button press function
        if ((int)RevCMD[1] == 1 || (int)RevCMD[1] == 2) //press button by XYZ table
        {
          Serial.println(boxOccupy);
          Serial.println(sendXYZbtnStep);
          if (boxOccupy == false)
          {
            sendXYZbtnStep = 0;
            boxOccupy = true;
          }
          else if (boxOccupy == true)
          {
            if (proj != "")
            {
              if (sendXYZbtnStep == 0)
              {
                Serial.println(proj);
                if ((int)RevCMD[2] == 1)
                {
                  sdFile = SD.open(proj + "/PWR.txt", FILE_READ);
                }
                else if ((int)RevCMD[2] == 2)
                {
                  sdFile = SD.open(proj + "/RST.txt", FILE_READ);
                }
                else if ((int)RevCMD[2] == 3)
                {
                  sdFile = SD.open(proj + "/NMI.txt", FILE_READ);
                }
                else if ((int)RevCMD[2] == 4)
                {
                  sdFile = SD.open(proj + "/ID.txt", FILE_READ);
                }
                else if ((int)RevCMD[2] == 5)
                {
                  sdFile = SD.open(proj + "/RSV1.txt", FILE_READ);
                }
                else if ((int)RevCMD[2] == 6)
                {
                  sdFile = SD.open(proj + "/RSV2.txt", FILE_READ);
                }
                else if ((int)RevCMD[2] == 7)
                {
                  sdFile = SD.open(proj + "/RSV3.txt", FILE_READ);
                }
                else if ((int)RevCMD[2] == 8)
                {
                  sdFile = SD.open(proj + "/RSV4.txt", FILE_READ);
                }
                if (sdFile)
                {

                  Serial.println("Read project:" + proj);
                  loc = "";
                  while (sdFile.available())
                  {
                    //Serial.write(sdFile.read());
                    loc = loc + (char)sdFile.read();
                  }
                  Serial.println(loc);
                  sdFile.close();
                  if (loc != "")
                  {

                    String x_loc = "";
                    String y_loc = "";
                    //String z_loc="";
                    x_loc = getValue(loc, ',', 1);
                    y_loc = getValue(loc, ',', 2);
                    loc = "G90 x" + x_loc + "y" + y_loc + "\r\n"; //Move to button location
                    if ((int)RevCMD[1] == 1)
                    {
                      XYZ1Loc[0] = atof(x_loc.c_str());
                      XYZ1Loc[1] = atof(y_loc.c_str());
                      XYZ1Loc[2] = atof(0);
                    }
                    else if ((int)RevCMD[1] == 2)
                    {
                      XYZ2Loc[0] = atof(x_loc.c_str());
                      XYZ2Loc[1] = atof(y_loc.c_str());
                      XYZ2Loc[2] = atof(0);
                    }
                    sendXYZbtnStep = 1;
                    sendXYZCMD = false;
                  }
                  else
                  {
                    SendCMDByte = 1;
                    SendCMD[0] = 2;   //return empty in the file
                    if (CMDFromBTorLan == true)
                    {
                      BT.write(SendCMD, 1);
                    }
                    /*
                      else
                      {
                      UDPSend(1);
                      }
                      boxOccupy = false;
                      ClrCMD();
                    */
                  }
                }
                else
                {
                  Serial.println("error open file");
                  SendCMDByte = 1;
                  SendCMD[0] = 1;   //return error open file
                  if (CMDFromBTorLan == true)
                  {
                    BT.write(SendCMD, 1);
                  }
                  //else
                  //{
                  //  UDPSend(1);
                  //}
                  /*
                    boxOccupy = false;
                    ClrCMD();
                  */
                }
              }
              else if (sendXYZbtnStep == 1)
              {
                Serial.print(loc);
                XYZRes = CMDtoXYZ((int)RevCMD[1], loc, true);
                delay(100);
                if (XYZRes.indexOf("ok") >= 0 || XYZRes.indexOf("Idle") >= 0)
                {
                  sendXYZbtnStep = 2;
                  XYZRes = "";
                }
              }
              else if (sendXYZbtnStep == 2)
              {
                sendXYZCMD = false;
                if (XYZRes.indexOf("Idle") < 0)
                {
                  Serial.print(loc);
                  loc = "?\r\n"; //Query
                  XYZRes = CMDtoXYZ((int)RevCMD[1], loc, true);
                  delay(100);
                }
                else
                {
                  sendXYZbtnStep = 3;
                  sendXYZCMD = false;
                }
              }
              else if (sendXYZbtnStep == 3)
              {
                sendXYZCMD = false;
                loc = "G90 z15\r\n"; //plug
                Serial.print(loc);
                XYZRes = CMDtoXYZ((int)RevCMD[1], loc, true);
                delay(100);
                if (XYZRes.indexOf("ok") >= 0)
                {
                  sendXYZbtnStep = 4;
                }
                startTime = millis();
              }
              else if (sendXYZbtnStep == 4)
              {
                currentTime = millis();
                if (currentTime - startTime >= ((int)RevCMD[3] + 1) * 1000)
                {
                  sendXYZbtnStep = 5;
                  sendXYZCMD = false;
                  XYZRes = "";
                  startTime = millis();

                }
              }
              else if (sendXYZbtnStep == 5)
              {
                currentTime = millis();
                if (currentTime - startTime >= 300)
                {
                  XYZRes = "";
                  sendXYZCMD = false;
                  loc = "G90 z0\r\n"; //unplug
                  Serial.print(loc);
                  XYZRes = CMDtoXYZ((int)RevCMD[1], loc, true);
                  startTime = millis();
                }

                if (XYZRes.indexOf("ok") >= 0)
                {
                  //ClrCMD();
                  Udp.parsePacket();
                  SendCMDByte = 1;
                  SendCMD[0] = 0;
                  sendXYZbtnStep = 6;
                  if (CMDFromBTorLan == true)
                  {
                    BT.write(SendCMD, 1);
                  }
                  /*
                    else
                    {
                    UDPSend(1);
                    }
                  */
                  //boxOccupy = false;

                }
              }
            }
            else
            {
              SendCMD[0] = 4;      //return project name is empty
              if (CMDFromBTorLan == true)
              {
                BT.write(SendCMD, 1);
              }
              else
              {
                SendCMDByte = 1;
                SendCMD[0] = 4;
                //UDPSend(1);
              }
              //boxOccupy = false;
              //ClrCMD();
            }
          }
        }
        else if ((int)RevCMD[1] == 3) //press button by relay
        {
          if (boxOccupy == false)
          {
            boxOccupy = true;
            digitalWrite(relay[(int)RevCMD[2] + 7], HIGH);
            UDPSend(1);
            startTime = millis();
          }
          else
          {
            currentTime = millis();
            if (currentTime - startTime > (int)RevCMD[3] * 1000)
            {
              digitalWrite(relay[(int)RevCMD[2] + 7], LOW);
              SendCMDByte = 1;
              SendCMD[0] = 0;
            }
          }
        }
        break;


      case 3:        //relay function
        if ((int)RevCMD[1] != 0 && (int)RevCMD[1] < 17 && (int)RevCMD[2] != 0 && (int)RevCMD[2] < 3)
        {
          if ((int)RevCMD[2] == 2)   //turn on relay
          {
            digitalWrite(relay[(int)RevCMD[1] - 1], HIGH);
            SendCMD[0] = (byte)0;

          }
          else if ((int)RevCMD[2] == 1)  //turn off relay
          {
            digitalWrite(relay[(int)RevCMD[1] - 1], LOW);
            SendCMD[0] = (byte)0;
          }
        }
        else   //CMD error
        {
          SendCMD[0] = (byte)1;
        }
        UDPSend(1);
        ClrCMD();
        break;


      case 4:
        if ((int)RevCMD[1] != 0 && (int)RevCMD[1] < 10 && (int)RevCMD[2] != 0 && (int)RevCMD[2] < 3)
        {
          if (USBBox1.read(14) == 1) //If fan in box is running, turn on/off USB
          {
            if ((int)RevCMD[2] == 1)   //turn off USB
            {
              USBBox1.write((int)RevCMD[1] - 1, HIGH);
            }
            else if ((int)RevCMD[2] == 2)   //turn on USB
            {
              USBBox1.write((int)RevCMD[1] - 1, LOW);
            }
            SendCMD[0] = (byte)0; //Return command executed
          }
          else   //If fan in box is stopped, turn off LAN and USB relaies.
          {
            for (int i = 0; i < 13; i++)
            {
              USBBox1.write(i, LOW);
            }
            SendCMD[0] = 128;
          }

        }
        else
        {
          SendCMD[0] = (byte)1; //Return command format error
        }
        UDPSend(1);
        ClrCMD();
        break;

      case 5:
        Serial.print("Pin read:");
        Serial.println(USBBox1.read(14));
        if ((int)RevCMD[1] != 0 && (int)RevCMD[1] < 6 && (int)RevCMD[2] != 0 && (int)RevCMD[2] < 3)
        {
          if (USBBox1.read(14) == 1) //If fan in box is running, turn on/off lan
          {
            if ((int)RevCMD[2] == 1)   //turn off LAN
            {
              USBBox1.write((int)RevCMD[1] + 8, HIGH);
            }
            else if ((int)RevCMD[2] == 2)   //turn on LAN
            {
              USBBox1.write((int)RevCMD[1] + 8, LOW);
            }
            SendCMD[0] = (byte)0;
          }
          else   //If fan in box is stopped, turn off LAN and USB relaies.
          {
            for (int i = 0; i < 13; i++)
            {
              USBBox1.write(i, LOW);
            }
            SendCMD[0] = 128;
          }

        }
        else
        {
          SendCMD[0] = (byte)1;
        }
        UDPSend(1);
        ClrCMD();
        break;


      case 10:
        if (RevCMD[1] != 0 && RevCMD[1] < 3)
        {
          SendCMD[0] = 0;
          SendCMD[1] = (int)digitalRead(digitalIn[(int)RevCMD[1] - 1]);
        }
        else
        {
          SendCMD[0] = 1;
          SendCMD[0] = (byte)0;
        }
        UDPSend(2);
        ClrCMD();
        break;

      case 11:
        if (RevCMD[1] != 0 && RevCMD[1] < 3)
        {
          SendCMD[0] = 0;
          SendCMD[1] = (int)(((float)analogRead(analogIn[RevCMD[1] - 1]) * 5 / 1024) + 0.5);

        }
        else
        {
          SendCMD[0] = 1;
          SendCMD[1] = 0;
        }
        UDPSend(2);
        ClrCMD();
        break;



      case 12:
        if (boxOccupy == false)
        {
          boxOccupy = true;
          UDPSend(1);
          COMIndex2 = 0;
          //Serial3.write((byte)51);
          Serial3.write((byte)((int)RevCMD[1] + 50));
          Serial3.write((byte)((int)RevCMD[2]));
          Serial3.write((byte)((int)RevCMD[3]));

        }
        else
        {
          if (COMIndex2 >= 7)
          {
            SendCMDByte = 2;
            SendCMD[0] = (byte)0;
            SendCMD[1] = RevCMD2[6];
            //UDPSend(2);
            //ClrCMD();
            //boxOccupy = false;
            Serial.print("return LED Count");
          }
        }


        break;





      case 8:   //LED detection
        if (boxOccupy == false)
        {
          COMIndex2 = 0;
          Serial3.write(RevCMD[1]);
          SendCMD[0] = 112;
          UDPSend(1);
          boxOccupy = true;
        }

        //Serial3.write(RevCMD[1]);

        break;


      case 99:   //Self check

        if ((int)RevCMD[1] == 0)
        {
          //resetFunc();
          InitialBox();
        }
        else
        {
          BoxCheck();
        }
        ClrCMD();
        break;

      case 80:
        for (int i = 0; i <= 5; i++)
        {
          EEPROM.write(i, RevCMD[i + 1]);
        }


        if (RevCMD[1] == 1)
        {
          EthReturn = Ethernet.begin(mac);
        }
        else
        {
          for (int i = 0; i < 4; i++)
          {
            ip[i] = RevCMD[i + 2];
          }
          Ethernet.begin(mac, ip);
        }
        if (EthReturn == 0)
        {
          Serial.println("Failed to configure Ethernet using DHCP");
          // Check for Ethernet hardware present
          if (Ethernet.hardwareStatus() == EthernetNoHardware)
          {
            Serial.println("Ethernet shield was not found.  Sorry, can't run without hardware. :(");
          }
          else if (Ethernet.linkStatus() == LinkOFF)
          {
            Serial.println("Ethernet cable is not connected.");
          }
        }

        Udp.begin(localPort);

        OLEDOn();

        Serial.write((byte)80);
        Serial.write((byte)0);
        Serial.write((byte)255);
        timerEvent = t.after(60000, OLEDOff);  //turn off OLED after 1 minute
        break;



      case 81:
        Serial.println(81);
        proj = "";
        for (int j = 1; j < packetSize; j++)
        {

          proj = proj + RevCMD[j];
        }
        Serial.println(proj);
        RevCMD[0] = 0;
        Udp.beginPacket(Udp.remoteIP(), 5901);
        Udp.write(RevCMD, 1);
        Udp.endPacket();
        //Serial.write((byte)0);
        break;

      case 13:  //buzzer detection
        if (boxOccupy == false)
        {
          boxOccupy = true;
          buzzerOn = 0;
          startTime = millis();

        }
        else
        {
          buzzerOn = pulseIn(buzzerDetect, HIGH);
          currentTime = millis();
          if (currentTime - startTime > 5000 || buzzerOn > 500)
          {
            SendCMDByte = 2;
            SendCMD[0] = (byte)0;
            if (buzzerOn > 500)
            {
              SendCMD[1] = (byte)2;
            }
            else
            {
              SendCMD[1] = (byte)1;
            }
            //UDPSend(2);
            //ClrCMD();
            //boxOccupy = false;
          }
        }
        break;


      case 14:
        KBMS_incomingByte=packetSize;
        KBMS_I2C_Addr = (int)RevCMD[1] + 1;
        //Serial.println(KBMS_I2C_Addr);
        Wire.beginTransmission(KBMS_I2C_Addr);
        for (int i = 2; i < packetSize; i++)
        {
          Wire.write(RevCMD[i]);
          Serial.println((int)RevCMD[i]);
        }
        Wire.endTransmission();
        SendCMD[0] = (byte)0;
        UDPSend(1);
        ClrCMD();
        break;



      case 90:   //XYZ remote control
        int intInitReturn = 0;
        String CMD = "";
        String res = "";
        String XYZState = "";
        String X_loc;
        String Y_loc;
        String Z_loc;
        if ((int)RevCMD[2] == 0) //Query XYZ table 1 or 2
        {
          XYZRes = QueryXYZ((int)RevCMD[1]);
          XYZState = getValue(XYZRes, ',', 0);
          X_loc = getValue(XYZRes, ',', 1);
          Y_loc = getValue(XYZRes, ',', 2);
          Z_loc = getValue(XYZRes, ',', 3);
          Serial.println("State:" + XYZState);
          Serial.println("X Location:" + X_loc);
          Serial.println("Y Location:" + Y_loc);
          Serial.println("Z Location:" + Z_loc);
          RevCMD[3] = (byte)intInitReturn;
          RevCMD[4] = (byte)255;
          Udp.beginPacket(Udp.remoteIP(), 5901);
          Udp.write(RevCMD);
          Udp.endPacket();
          //ether.sendUdp(RevCMD, 4, myPort, destIP, destPort);
          ClrCMD();
        }
        else if ((int)RevCMD[2] == 1) //Unlock XYZ table 1 or 2
        {
          Serial.println("Unlock XYZ.");
          //XYZCMD=char(24) + "\r\n";
          XYZCMD = char(24);
          XYZRes = CMDtoXYZ((int)RevCMD[1], XYZCMD, true);
          XYZCMD = "$x\r\n";
          XYZRes = CMDtoXYZ((int)RevCMD[1], XYZCMD, true);
          //intInitReturn=UnlockXYZ((int)RevCMD[1]);
          Serial.println(XYZRes);
          if (XYZRes.indexOf("ok") >= 0)
          {
            RevCMD[3] = (byte)0;
          }
          else
          {
            RevCMD[3] = (byte)1;
          }
          //RevCMD[3]=(byte)intInitReturn;
          RevCMD[4] = (byte)255;
          if (CMDFromBTorLan == true)
          {
            BT.write(RevCMD, 5);
          }
          else
          {
            Udp.beginPacket(Udp.remoteIP(), 5901);
            Udp.write(RevCMD, 5);
            Udp.endPacket();
          }

          //ether.sendUdp(RevCMD, 4, myPort, destIP, destPort);
          ClrCMD();
        }
        else if ((int)RevCMD[2] == 2) //XYZ table 1 or 2 homing function
        {
          Serial.println(sendXYZbtnStep);
          if (boxOccupy == false)
          {
            sendXYZbtnStep = 1;
            boxOccupy = true;
            sendXYZCMD = false;
            XYZCMD = char(24);
            XYZRes = CMDtoXYZ((int)RevCMD[1], XYZCMD, true);
            delay(100);
            Serial.println(XYZRes);

            sendXYZCMD = false;
            XYZCMD = "$x\r\n";
            XYZRes = CMDtoXYZ((int)RevCMD[1], XYZCMD, true);
            delay(100);
            Serial.println(XYZRes);
            Serial.println("XYZ homing");
            sendXYZCMD = false;
            XYZCMD = "$h\r\n"; //Send homing command
            XYZRes = CMDtoXYZ((int)RevCMD[1], XYZCMD, true);
            delay(100);
            Serial.println(XYZRes);
            Serial.println("Unlock XYZ.");

            XYZRes = "";
          }
          else if (sendXYZbtnStep == 1)
          {
            if (XYZRes.indexOf("Idle") < 0)
            {
              sendXYZCMD = false;
              loc = "?\r\n";
              //XYZRes=QueryXYZ((int)RevCMD[1]);
              XYZRes = CMDtoXYZ((int)RevCMD[1], loc, true);
              Serial.print("___");
              Serial.println(XYZRes);
              delay(200);
            }
            else
            {
              sendXYZbtnStep = 2;
            }
          }
          else if (sendXYZbtnStep == 2)
          {
            if (XYZRes.indexOf("Idle") >= 0)
            {
              sendXYZCMD = false;
              XYZCMD = "g92 x0y0z0\r\n"; //Make current homing position is x0y0z0
              XYZRes = CMDtoXYZ((int)RevCMD[1], XYZCMD, true);
              Serial.println(XYZRes);
              delay(100);
              sendXYZCMD = false;
              XYZCMD = "?\r\n"; //Make current homing position is x0y0z0
              XYZRes = CMDtoXYZ((int)RevCMD[1], XYZCMD, true);
              Serial.println(XYZRes);
              delay(100);
              sendXYZCMD = false;
              XYZCMD = "$x\r\n";         //Unlock XYZ table
              XYZRes = CMDtoXYZ((int)RevCMD[1], XYZCMD, true);
              Serial.println(XYZRes);
              delay(100);
              if ((int)RevCMD[1] == 1)
              {
                for (int i = 0; i < 3; i++)
                {
                  XYZ1Loc[i] = 0;
                }
              }
              else if ((int)RevCMD[1] == 2)
              {
                for (int i = 0; i < 3; i++)
                {
                  XYZ2Loc[i] = 0;
                }
              }

              RevCMD[3] = (byte)0;
            }
            else
            {
              RevCMD[3] = (byte)1;
            }

            RevCMD[4] = (byte)255;
            if (CMDFromBTorLan == true)
            {
              BT.write(RevCMD, 5);
            }
            else
            {
              SendCMDByte = 5;
              for (int i = 0; i < 5; i++)
              {
                SendCMD[i] = RevCMD[i];
              }
              //Udp.beginPacket(Udp.remoteIP(), 5901);
              //Udp.write(RevCMD, 5);
              //Udp.endPacket();
            }

            //ether.sendUdp(RevCMD, 4, myPort, destIP, destPort);
            //ClrCMD();
            //boxOccupy = false;
          }

        }
        else if ((int)RevCMD[2] == 3)  //XYZ moving step
        {
          Serial.println("XYZ Move");
          sendXYZCMD = false;
          if ((int)RevCMD[4] == 1) //RevCMD[4]=1->move step 0.01mm, RevCMD[4]=2->move step 0.1mm, RevCMD[4]=3->move step 1mm
          {
            moveStep = 0.01;
          }
          else if ((int)RevCMD[4] == 2)
          {
            moveStep = 0.1;
          }
          else if ((int)RevCMD[4] == 3)
          {
            moveStep = 1;
          }
          if ((int)RevCMD[3] == 1 || (int)RevCMD[3] == 2) //RevCMD[3]=1->positive direction of X, RevCMD[3]=2->negative direction of X, ,
          {
            if ((int)RevCMD[3] == 2)
            {
              moveStep = moveStep * -1;
            }
            if ((int)RevCMD[1] == 1)
            {
              if (XYZ1Loc[0] + moveStep >= 0 && XYZ1Loc[0] + moveStep <= 59.8 )
              {
                XYZ1Loc[0] = XYZ1Loc[0] + moveStep;
                XYZCMD = "G90 x" + (String)XYZ1Loc[0] + " f3000\r\n"; //Send X move command
              }

            }
            else if ((int)RevCMD[1] == 2)
            {
              if (XYZ2Loc[0] + moveStep >= 0 && XYZ2Loc[0] + moveStep <= 59.8 )
              {
                XYZ2Loc[0] = XYZ2Loc[0] + moveStep;
                XYZCMD = "G90 x" + (String)XYZ2Loc[0] + " f3000\r\n"; //Send X move command
              }
            }
          }
          else if ((int)RevCMD[3] == 3 || (int)RevCMD[3] == 4) //RevCMD[3]=3->positive direction of Y, RevCMD[3]=4->negative direction of Y
          {
            if ((int)RevCMD[3] == 4)
            {
              moveStep = moveStep * -1;
            }
            if ((int)RevCMD[1] == 1)
            {
              if (XYZ1Loc[2] + moveStep >= 0 && XYZ1Loc[2] + moveStep <= 19 )
              {
                XYZ1Loc[2] = XYZ1Loc[2] + moveStep;
                XYZCMD = "G90 z" + (String)XYZ1Loc[2] + " f3000\r\n"; //Send X move command
              }

            }
            else if ((int)RevCMD[1] == 2)
            {
              if (XYZ2Loc[2] + moveStep >= 0 && XYZ2Loc[2] + moveStep <= 19 )
              {
                XYZ2Loc[2] = XYZ2Loc[2] + moveStep;
                XYZCMD = "G90 z" + (String)XYZ2Loc[2] + " f3000\r\n"; //Send X move command
              }

            }
          }
          else if ((int)RevCMD[3] == 5 || (int)RevCMD[3] == 6) //RevCMD[3]=5->positive direction of Z, RevCMD[3]=6->negative direction of Z
          {
            if ((int)RevCMD[3] == 5)
            {
              moveStep = moveStep * -1;
            }
            if ((int)RevCMD[1] == 1)
            {
              if (XYZ1Loc[1] + moveStep >= 0 && XYZ1Loc[1] + moveStep <= 137 )
              {
                XYZ1Loc[1] = XYZ1Loc[1] + moveStep;
                XYZCMD = "G90 y" + (String)XYZ1Loc[1] + " f3000\r\n"; //Send X move command
              }

            }
            else if ((int)RevCMD[1] == 2)
            {
              if (XYZ2Loc[1] + moveStep >= 0 && XYZ2Loc[1] + moveStep <= 137 )
              {
                XYZ2Loc[1] = XYZ2Loc[1] + moveStep;
                XYZCMD = "G90 y" + (String)XYZ2Loc[1] + " f3000\r\n"; //Send X move command
              }
            }
          }
          if ((int)RevCMD[1] == 1)
          {
            ser1Trans = true;
          }
          else if ((int)RevCMD[1] == 2)
          {
            ser2Trans = true;
          }
          XYZRes = CMDtoXYZ((int)RevCMD[1], XYZCMD, false);
          if ((int)RevCMD[1] == 1)
          {
            ser1Trans = false;
          }
          else if ((int)RevCMD[1] == 2)
          {
            ser2Trans = false;
          }
          ClrCMD();
          /*
            Serial.println(XYZRes);
            if(XYZRes.indexOf("ALARM")>=0)
            {
            RevCMD[4]=(byte)1;
            }
            else if(XYZRes.indexOf("error")>=0)
            {
            RevCMD[4]=(byte)2;
            }
            else
            {
            RevCMD[4]=(byte)0;
            }
            //RevCMD[3]=(byte)intInitReturn;
            RevCMD[5]=(byte)255;
            if(RevCMD[4]!=(byte)0)
            {
            if(CMDFromBTorLan==true)
            {
              BT.write(RevCMD,6);
            }
            else
            {
              Udp.beginPacket(Udp.remoteIP(), 5901);
              Udp.write(RevCMD,6);
              Udp.endPacket();
            }
            }
          */
        }
        else if ((int)RevCMD[2] == 4) //save button location to SD
        {

          proj = "";
          for (int j = 4; j < sizeof(RevCMD); j++)
          {
            if (int(RevCMD[j]) != -1)
            {
              proj = proj + RevCMD[j];
              Serial.print(int(RevCMD[j]));
            }
            else
            {
              break;
            }

          }
          Serial.println(proj);
          if (!SD.begin(4))
          {
            Serial.print("error to write to SD");
            Serial.println(proj);
            RevCMD[4] = 2;
            RevCMD[5] = (byte)255;
          }
          else
          {
            if (! SD.exists(proj.c_str()))
            {
              SD.mkdir(proj.c_str());
            }
            if ((int)RevCMD[3] == 1)
            {
              proj = proj + "/PWR.txt";
            }
            else if ((int)RevCMD[3] == 2)
            {
              proj = proj + "/RST.txt";
            }
            else if ((int)RevCMD[3] == 3)
            {
              proj = proj + "/NMI.txt";
            }
            else if ((int)RevCMD[3] == 4)
            {
              proj = proj + "/ID.txt";
            }
            else if ((int)RevCMD[3] == 5)
            {
              proj = proj + "/RSV1.txt";
            }
            else if ((int)RevCMD[3] == 6)
            {
              proj = proj + "/RSV2.txt";
            }
            else if ((int)RevCMD[3] == 7)
            {
              proj = proj + "/RSV3.txt";
            }
            else if ((int)RevCMD[3] == 8)
            {
              proj = proj + "/RSV4.txt";
            }
            else if ((int)RevCMD[3] == 9)
            {
              proj = proj + "/USB1.txt";
            }
            else if ((int)RevCMD[3] == 10)
            {
              proj = proj + "/USB2.txt";
            }
            else if ((int)RevCMD[3] == 11)
            {
              proj = proj + "/USB3.txt";
            }
            else if ((int)RevCMD[3] == 12)
            {
              proj = proj + "/USB4.txt";
            }
            else if ((int)RevCMD[3] == 13)
            {
              proj = proj + "/LAN1.txt";
            }
            else if ((int)RevCMD[3] == 14)
            {
              proj = proj + "/LAN2.txt";
            }
            else if ((int)RevCMD[3] == 15)
            {
              proj = proj + "/LAN3.txt";
            }
            else if ((int)RevCMD[3] == 16)
            {
              proj = proj + "/LAN4.txt";
            }
            if (SD.exists(proj.c_str()))
            {
              SD.remove(proj.c_str());
            }
            sdFile = SD.open(proj.c_str(), FILE_WRITE);
            Serial.println(proj);
            if (sdFile)
            {
              XYZRes = "";
              for (int i = 0; i < 30; i++)
              {
                delay(1000);
                XYZRes = QueryXYZ((int)RevCMD[1]);
                Serial.println(XYZRes);
                if (XYZRes.length() > 7 && XYZRes.indexOf("Idle") >= 0)
                {
                  break;
                }
              }
              Serial.print("Write location to ");
              Serial.println(proj);
              sdFile.println(XYZRes);
              sdFile.close();
              Serial.println("done.");
              RevCMD[4] = 0;
              RevCMD[5] = (byte)255;

            }
            else
            {
              // if the file didn't open, print an error:
              Serial.print("error to write to ");
              Serial.println(proj);
              RevCMD[4] = 1;
              RevCMD[5] = (byte)255;
            }
          }


          if (CMDFromBTorLan == true)
          {
            BT.write(RevCMD, 6);
          }
          else
          {
            Udp.beginPacket(Udp.remoteIP(), 5901);
            Udp.write(RevCMD, 6);
            Udp.endPacket();
          }
          ClrCMD();
        }
        else if ((int)RevCMD[2] == 5) //List SD folders and files
        {
          /*
            while (sdFile.openNext(sd.vwd(), O_READ))
            {
            file.getFilename(cnamefile);
            file.close();
            //sdata = sdata + String(cnamefile) + ";";

            }
          */
        }
        ClrCMD;
        break;





    }
    packetSize = 0;
  }
}

void InitialBox()
{
  // put your setup code here, to run once:
  pinMode(LED_BUILTIN, OUTPUT);
  pinMode(WakeUpBtn, INPUT);
  pinMode(buzzerDetect, INPUT);
  pinMode(buzzerLED, OUTPUT);
  USBBox1.begin();
  for (int i = 0; i < 16; i++)
  {
    USBBox1.write(i, LOW);
  }

  Serial.begin(9600);
  Serial3.begin(19200);    //Serial port for LED box
  Serial1.begin(9600);   //Serial port for XYZ1 table
  Serial2.begin(9600);   //Serial port for XYZ2 table
  BT.begin(9600);          //Serial port for bluetooth
  //Clear display
  if (!display.begin(SSD1306_SWITCHCAPVCC, 0x3C)) { // Address 0x3C for 128x32
    Serial.println(F("SSD1306 allocation failed"));
    for (;;); // Don't proceed, loop forever
  }

  //display OTS Box V1.2
  display.clearDisplay();
  display.setFont(&FreeSans9pt7b);
  display.setTextSize(1);             //Set font size
  display.setTextColor(SSD1306_WHITE);        //Set font color
  display.setCursor(0, 13);            //Set the start location of the first line string
  display.print("OTS Box");
  display.setCursor(0, 28);
  display.print("V1.2");
  display.display();

  // start Ethernet and UDP

  for (int i = 0; i < 5; i++)
  {
    Serial.println(EEPROM.read(i));
  }
  if (EEPROM.read(0) == 1)
  {
    EthReturn = Ethernet.begin(mac);
  }
  else if (EEPROM.read(0) == 2)
  {
    for (int i = 0; i < 4; i++)
    {
      ip[i] = EEPROM.read(i + 1);
    }
    Ethernet.begin(mac, ip);
  }


  Serial.println(Ethernet.localIP());

  if (Ethernet.hardwareStatus() == EthernetNoHardware)
  {
    Serial.println("Ethernet shield was not found or Ethernet cable is not connected.");
  }
  else
  {

    getIP = true;

  }
  Udp.begin(localPort);
  OLEDOn();


  if (!SD.begin(4))
  {
    Serial.println("Initialize SD card failed.");
  }
  else
  {
    Serial.println("Initialize SD card completed.");
    SD.ls(&Serial, LS_R);
    /*
      while (file.openNext(SD.vwd(), O_READ))
      {
      file.printName(&Serial);//->I need this output in char*
      if (file.isDir())
      {
        // Indicate a directory.
        Serial.write('/');
      }
      Serial.println();
      file.close();
      }
    */
  }



  for (int i = 0; i < 4; i++)
  {
    pinMode(ACOut[i], OUTPUT);
    pinMode(ACIn[i], INPUT);
  }
  for (int i = 0; i < 16; i++)
  {
    pinMode(relay[i], OUTPUT);
    digitalWrite(relay[i], LOW);
  }
  for (int i = 0; i < 2; i++)
  {
    pinMode(digitalIn[i], INPUT);
    pinMode(analogIn[i], INPUT);

  }
  /*
    for(int i=0;i<2;i++)
    {
    pinMode(SUTPwrOk[i], INPUT);
    }
  */
  BtnTime[0] = 0;
  BtnTime[1] = 0;
  Wire.begin();

}


void BoxCheck()
{
  int boxState[] = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
  IOState = 0;
  for (int i = 0; i < 4; i++)
  {
    IOState = IOState + (int(digitalRead(ACOut[i])) << i);
  }
  SendCMD[0] = IOState; //record AC status
  IOState = 0;
  for (int i = 0; i < 8; i++)
  {
    IOState = IOState + (int(digitalRead(relay[i])) << i);
  }
  SendCMD[1] = IOState; //record relay 1-7 status
  IOState = 0;
  for (int i = 8; i < 16; i++)
  {
    IOState = IOState + (int(digitalRead(relay[i])) << i - 8);
  }
  SendCMD[2] = IOState; //record relay 8-16 status
  IOState = 0;
  for (int i = 0; i < 8; i++)
  {
    IOState = IOState + (int(!USBBox1.read(i)) << i);
  }
  SendCMD[3] = IOState; //record usb 1-8 status on USB_LAN box
  IOState = 0;
  IOState = int(!USBBox1.read(8));
  SendCMD[4] = IOState; //record usb 9 status on USB_LAN box
  IOState = 0;
  for (int i = 9; i < 14; i++)
  {
    IOState = IOState + (int(!USBBox1.read(i)) << i - 9);
  }
  SendCMD[5] = IOState; //record Ethernet 1-5 status on USB_LAN box

  /*
    if (!SD.begin(4))
    {
    SendCMD[6]=0;
    }
    else
    {
    SendCMD[6]=0;
    }
    RevCMD[0]=boxState;
  */
  //Check LED box status
  COMIndex2 = 0;
  Serial3.write((byte)0);    //send check command to LED box
  delay(500);
  while (Serial3.available() > 0)
  {
    RevCMD2[COMIndex2] = Serial3.read();
    COMIndex2 += 1;

  }
  if ((int)RevCMD2[0] == 99) //record LED box status
  {
    SendCMD[6] = 1;        //LED box is detected
  }
  else
  {
    SendCMD[6] = 0;        //LED box is not detected
  }
  RevCMD2[0] = 0;


  //check XYZ1
  sendXYZCMD = false;
  XYZRes = CMDtoXYZ(1, "$x\r\n", true);
  if (XYZRes.indexOf("ok") >= 0)
  {
    SendCMD[7] = 1;     //XYZ1 is detected
  }
  else
  {
    SendCMD[7] = 0;     //XYZ1 is not detected
  }


  //check XYZ2
  sendXYZCMD = false;
  XYZRes = CMDtoXYZ(2, "$x\r\n", true);
  if (XYZRes.indexOf("ok") >= 0)
  {
    SendCMD[8] = 1;     //XYZ2 is detected
  }
  else
  {
    SendCMD[8] = 0;     //XYZ2 is not detected
  }
  UDPSend(9);
}

void ClrCMD()
{
  for (int j = 0; j < sizeof(RevCMD); j++)
  {
    RevCMD[j] = (char)0;
  }
  COMIndex = 0;
}

void BtnMove(int len)
{
  /*
    for(int x = 0; x < len; x++)
    {
    digitalWrite(BtnStep,HIGH);
    delayMicroseconds(900);
    digitalWrite(BtnStep,LOW);
    delayMicroseconds(900);
    }
  */
}

void ReturnCMD(byte CMD, boolean result)
{
  //Serial.write(CMD);
  //Serial.write((byte)0);
  //Serial.write((byte)0);
  //Serial.write((byte)127);
  RevCMD[0] = CMD;
  RevCMD[1] = (byte)0;
  RevCMD[2] = (byte)255;
  Udp.beginPacket(Udp.remoteIP(), 5901);
  Udp.write(RevCMD, 3);
  Udp.endPacket();
  //ether.sendUdp(RevCMD, 4, myPort, destIP, destPort);

}


String CMDtoXYZ(int XYZNo, String CMD, boolean retVal)
{
  String res;
  if (sendXYZCMD == false)
  {
    if (XYZNo == 2)
    {
      Serial2.write(CMD.c_str());
    }
    else if (XYZNo == 1)
    {
      Serial1.write(CMD.c_str());
      Serial.println(CMD.c_str());
    }
    sendXYZCMD = true;
  }
  if (retVal == true)
  {
    if (XYZNo == 2)
    {
      if (Serial2.available() > 0)
      {
        while (Serial2.available() > 0)
        {
          res = res + Serial2.readString();
        }
        return res;

        sendXYZCMD = false;
      }
      else
      {
        return "";
      }
    }
    else if (XYZNo == 1)
    {

      if (Serial1.available() > 0)
      {
        while (Serial1.available() > 0)
        {
          res = res + Serial1.readString();
        }
        Serial.println("@@" + res + "@@");
        return res;
        sendXYZCMD = false;
      }
      else
      {
        return "";
      }

    }


  }
  else
  {
    return "";
  }
}


String QueryXYZ(int XYZNo)
{
  Serial.println("XYZ Query");
  String CMD;
  String res;
  String XYZState;
  String X_loc;
  String Y_loc;
  String Z_loc;
  CMD = "?\r\n";
  Serial.println(CMD);
  if (XYZNo == 2)
  {
    Serial2.write(CMD.c_str());
  }
  else if (XYZNo == 1)
  {
    Serial1.write(CMD.c_str());
  }
  delay(5);

  for (int i = 0; i < 500; i++)
  {
    if (XYZNo == 2)
    {
      while (Serial2.available() > 0)
      {
        res = res + Serial2.readString();
      }
    }
    else if (XYZNo == 1)
    {
      while (Serial1.available() > 0)
      {
        res = res + Serial1.readString();
      }
    }
  }
  Serial.println(res);
  XYZState = getValue(res, '|', 0);
  XYZState = getValue(XYZState, '<', 1);
  //XYZState.remove(0,1);
  X_loc = getValue(getValue(res, '|', 1), ',', 0 );
  X_loc.remove(0, 5);
  Y_loc = getValue(getValue(res, '|', 1), ',', 1 );
  Z_loc = getValue(getValue(res, '|', 1), ',', 2 );
  return XYZState + "," + X_loc + "," + Y_loc + "," + Z_loc;
}


void serialEvent()
{
  // read one byte from serial port
  incomingByte = Serial.read();
  //Serial.print(incomingByte, DEC);
  RevCMD[COMIndex] = incomingByte;
  //Serial.write(incomingByte);

  //Serial.print(RevCMD[COMIndex]);
  if ((int)RevCMD[COMIndex] == -1)
  {
    packetSize = COMIndex;
    COMIndex = 0;
  }
  else
  {
    COMIndex++;
  }

}


void serialEvent3()
{
  // read one byte from serial port
  incomingByte2 = Serial3.read();
  //Serial.print(incomingByte2, DEC);
  if (COMIndex2 == 0)
  {
    RevCMD2[0] = 0;
    COMIndex2++;
  }
  RevCMD2[COMIndex2] = incomingByte2;
  Serial.println(int(RevCMD2[COMIndex2]));
  COMIndex2++;

  if (COMIndex2 == 7)
  {
    if ((int)RevCMD2[0] != 99)
    {
      if ((int)RevCMD[0] == 8)
      {
        SendCMDByte = 7;
        for (int i = 0; i < 7; i++)
        {
          SendCMD[i] = RevCMD2[i];
        }
        //Udp.beginPacket(Udp.remoteIP(), 5901);
        //Udp.write(RevCMD2, 6);
        //Udp.endPacket();
        COMIndex2 = 0;
        //boxOccupy = false;
        //ClrCMD();
      }
    }
    else if ((int)RevCMD2[0] == 99)
    {
      SendCMDByte = 1;
      SendCMD[0] = 0;
      //RevCMD[0] = 0;
      //Udp.beginPacket(Udp.remoteIP(), 5901);
      //Udp.write(RevCMD, 1);
      //Udp.endPacket();
      COMIndex2 = 0;
      //boxOccupy = false;
      //ClrCMD();
    }

  }

}

String getValue(String data, char separator, int index)
{
  int found = 0;
  int strIndex[] = { 0, -1 };
  int maxIndex = data.length() - 1;

  for (int i = 0; i <= maxIndex && found <= index; i++) {
    if (data.charAt(i) == separator || i == maxIndex) {
      found++;
      strIndex[0] = strIndex[1] + 1;
      strIndex[1] = (i == maxIndex) ? i + 1 : i;
    }
  }
  return found > index ? data.substring(strIndex[0], strIndex[1]) : "";
}

void OLEDOn()  //turn on OLED
{
  display.clearDisplay();
  display.setFont(&FreeSans9pt7b);
  display.setTextSize(1);
  display.setTextColor(SSD1306_WHITE);        //Set font color
  display.setCursor(0, 13);            //Set the start location of the first line string
  //display.print("IP:");        //print string
  //display.setCursor(0,15);             //Set the start location of the first line string
  if (Ethernet.linkStatus() == 1)
  {
    display.println(Ethernet.localIP());
  }
  else
  {
    display.println("0.0.0.0");
  }
  display.display();
  timerEvent = t.after(60000, OLEDOff);
}

void OLEDOff()  //turn off OLED
{
  display.clearDisplay();
  display.display();
  t.stop(timerEvent);
}

/*
  void serialEvent1()
  {
  while (Serial1.available()) {
    // get the new byte:
    char inChar = (char)Serial1.read();

    strSer1 += inChar;
    Serial.print(inChar);
    if(strSer1.indexOf("AL")>=0)
    {

      RevCMD[4]=(byte)1;
      RevCMD[5]=(byte)255;
      if(CMDFromBTorLan==true)
      {
        BT.write(RevCMD,6);
      }
      else
      {
         Udp.beginPacket(Udp.remoteIP(), 5901);
         Udp.write(RevCMD,6);
         Udp.endPacket();
      }
      strSer1="";
      delay(1000);
      XYZCMD=char(24);
      XYZRes=CMDtoXYZ((int)RevCMD[1],XYZCMD,true);
      Serial.println(XYZRes);
      XYZRes=CMDtoXYZ((int)RevCMD[1],"$x\r\n",true);
      Serial.println(XYZRes);
    }
  }
  }
*/
void serialEvent2()
{
  while (Serial2.available()) {
    // get the new byte:
    char inChar = (char)Serial2.read();
    Serial.print(inChar);
    strSer2 += inChar;
    if (strSer2.indexOf("AL") >= 0)
    {

      RevCMD[4] = (byte)1;
      RevCMD[5] = (byte)255;
      if (CMDFromBTorLan == true)
      {
        BT.write(RevCMD, 6);
      }
      else
      {
        Udp.beginPacket(Udp.remoteIP(), 5901);
        Udp.write(RevCMD, 6);
        Udp.endPacket();
      }
      strSer2 = "";
      delay(1000);
      XYZCMD = char(24);
      XYZRes = CMDtoXYZ((int)RevCMD[1], XYZCMD, true);
      Serial.println(XYZRes);
      XYZRes = CMDtoXYZ((int)RevCMD[1], "$x\r\n", true);
      Serial.println(XYZRes);
    }
  }
}


void ls(char *path) {
  SdBaseFile dir;
  if (!dir.open(path, O_READ) || !dir.isDir()) {
    Serial.println("bad dir");
    return;
  }
  dir.ls(&Serial, LS_R);
}

void UDPSend(int len)
{
  Udp.beginPacket(Udp.remoteIP(), 5901);
  Udp.write(SendCMD, len);
  Udp.endPacket();
  Serial.print("Send byte through UDP: ");
  Serial.print(len);
  Serial.println(" bytes");
  Serial.println("Sent data");
  for (int i = 0; i < len; i++)
  {
    Serial.print("Byte:");
    Serial.print(i);
    Serial.print(":");
    Serial.println(int(SendCMD[i]));
  }
}

TimedAction UDPAction     = TimedAction(80, ReceiveUDP);
TimedAction BoxAction =   TimedAction(70, BoxControl);



void loop()
{
  UDPAction.check();
  BoxAction.check();
}
