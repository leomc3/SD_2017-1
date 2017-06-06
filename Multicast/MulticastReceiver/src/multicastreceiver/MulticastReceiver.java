/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package multicastreceiver;
import java.io.*;
import java.net.*;
/**
 *
 * @author Leo
 */
public class MulticastReceiver {
  public static void main(String[] args) {
    MulticastSocket socket = null;
    DatagramPacket inPacket = null;
     DatagramPacket outPacket = null;
    byte[] inBuf = new byte[256];
    byte[] outBuf;
    final int PORT = 8888;
    String msg,msg2;
    
    try {
      //Prepare to join multicast group
      socket = new MulticastSocket(8888);
      InetAddress address = InetAddress.getByName("224.2.2.3");
      socket.joinGroup(address);
 
      while (true) {
          
        //recive
        inPacket = new DatagramPacket(inBuf, inBuf.length);
        socket.receive(inPacket);
        msg2 = new String(inBuf, 0, inPacket.getLength());
        System.out.println("From " + inPacket.getAddress() + " Msg : " + msg2);
        
        //input
        BufferedReader in = new BufferedReader(new InputStreamReader(System.in));
        msg = in.readLine();
        outBuf = msg.getBytes();
 
        //Send to multicast IP address and port
        outPacket = new DatagramPacket(outBuf, outBuf.length, address, PORT);
        socket.send(outPacket);
        System.out.println("Leo Reciver sends : " + msg);
        
      }
    } catch (IOException ioe) {
      System.out.println(ioe);
    }
  }
}