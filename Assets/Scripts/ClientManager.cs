using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.Net;
using System.Text;
using UnityEngine.UI;
using System.Threading;
public class ClientManager : MonoBehaviour
{
    //ip:192.168.1.7
    public string ipAddressstr;
    public int port;
    public Text ipTextToShow;
    //Socket
    private Socket ClientServer;

    //文本输入框
    public InputField inputTxt;
    public string inputMSGStr;

    //接收
    Thread t;
    public Text receiveTextCom;
    public string message;





    // Use this for initialization
    void Start()
    {
        ipTextToShow.text = ipAddressstr;
       // ConnectedToServer();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (message != null && message != "")
        {
            receiveTextCom.text = receiveTextCom.text + "\n" + message;
            message = "";
        }
    }


    /// <summary>
    /// 连接服务器
    /// </summary>
    public void ConnectedToServer()
    {
        ClientServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        //声明IP地址和端口
        IPAddress ServerAddress = IPAddress.Parse(ipAddressstr);
        EndPoint ServerPoint = new IPEndPoint(ServerAddress, port);

        ipAddressstr = IpInfo.ipStr;
        port = IpInfo.portStr;


        //开始连接
        ClientServer.Connect(ServerPoint);

        t = new Thread(ReceiveMSG);
        t.Start();

    }


    /// <summary>
    /// 接收消息
    /// </summary>
    /// <returns>“string”</returns>
    void ReceiveMSG()
    {
        while (true)
        {
            if (ClientServer.Connected == false)
            {
                break;
            }
            byte[] data = new byte[1024];
            int length = ClientServer.Receive(data);
            message = Encoding.UTF8.GetString(data, 0, length);
            //Debug.Log("有消息进来");

        }

    }


    /// <summary>
    /// 发送string类型数据
    /// </summary>
    /// <param name="input"></param>
    public void SendMSG()
    {

        Debug.Log("button Clicked");
        //message = "我：" + inputTxt.text;
        inputMSGStr = inputTxt.text;
        byte[] data = Encoding.UTF8.GetBytes(IpInfo.name+":"+inputMSGStr);
        ClientServer.Send(data);

    }



    private void OnDestroy()
    {
        ClientServer.Shutdown(SocketShutdown.Both);
        ClientServer.Close();
    }
    private void OnApplicationQuit()
    {
        OnDestroy();
    }
}
