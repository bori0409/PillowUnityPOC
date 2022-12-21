using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class tilt : MonoBehaviour
{
   
    private const int Port = 2000;
    public IPAddress ip4 = IPAddress.Parse("172.20.10.4");
    UdpClient socket ;
    IPEndPoint remoteEndPoint ;
    void Start()
    {

        remoteEndPoint = new IPEndPoint(IPAddress.Any, Port);
        socket = new UdpClient(remoteEndPoint);


        
        Debug.Log("WORKING");



    }

    async void doSomething()
    {
        var datagram = await byteStuff();
        string message = Encoding.ASCII.GetString(datagram, 0, datagram.Length);

        Debug.Log("messagse is:"+message);
    }

    async Task<byte[]> byteStuff()
    {

        var datagramReceived = await socket.ReceiveAsync();
        
        return  datagramReceived.Buffer;
    }
    



    // Update is called once per frame
    void Update()
    {
        doSomething();

        //var number = long.Parse(message, CultureInfo.InvariantCulture.NumberFormat);
        //  Debug.Log(number);


    }

    
}
