using UnityEngine;
using System.Collections;
using System.Threading;
using System.IO.Ports;

public class SerialReadNew : MonoBehaviour {

    public int control=-1;
    private MySerialPortThreadArduino mythread;
    // Use this for initialization
    void Start()
    {
        mythread = new MySerialPortThreadArduino(this);
        new Thread(mythread.Run).Start();
    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnApplicationQuit()
    {
        // 結束 Unity 關閉執行緒
        mythread.isRun = false;
    }

    public void getSerialPort(int port)
    {
        //Debug.Log("return:" + port);
        control = port;
    }


}


public class MySerialPortThreadArduino 
{
    public bool isRun = true;
    public int serialControl = -1;
    private SerialReadNew upperclass;

    public MySerialPortThreadArduino(SerialReadNew upperclass)
    {
        this.upperclass = upperclass;
    }

    public void Run()
    {
        SerialPort port = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
        
        // 開啟 RS232
        port.Open();

        // 持續讀取 RS232
        while (isRun)
        {
            string read = port.ReadLine();
            if (read.Length != 0) {
                serialControl = int.Parse(read);
                MonoBehaviour.print("Serial " + read);
            }
            else
            {
                serialControl = -1;
            }
            upperclass.getSerialPort(serialControl);
        }
        
    }
}
