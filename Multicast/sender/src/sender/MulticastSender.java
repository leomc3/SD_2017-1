/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package sender;

import java.io.*;
import java.net.*;
/**
 * @author Leo
 */
public class MulticastSender {
  public static void main(String[] args) {
    DatagramSocket socket = null;
    DatagramPacket outPacket = null;
    DatagramPacket inPacket = null;
    byte[] outBuf;
    byte[] inBuf = new byte[256];
    final int PORT = 8888;
 
    try {
      socket = new DatagramSocket();
      long counter = 0;
      String msg,msg2;
 
      while (true) {
            //input
        BufferedReader in = new BufferedReader(new InputStreamReader(System.in));
        String entrada = in.readLine();
        msg = entrada + counter;
        counter++;
        outBuf = msg.getBytes();
 
        //Send to multicast IP address and port
        InetAddress address = InetAddress.getByName("224.2.2.3");
        outPacket = new DatagramPacket(outBuf, outBuf.length, address, PORT);
 
        socket.send(outPacket);
 
        System.out.println("Leo Sender sends : " + msg);
        
        inPacket = new DatagramPacket(inBuf, inBuf.length);
        socket.receive(inPacket);
        msg2 = new String(inBuf, 0, inPacket.getLength());
        System.out.println("From " + inPacket.getAddress() + " Msg : " + msg2);
        
       
        
        try {
          Thread.sleep(500);
        } catch (InterruptedException ie) {
        }
      }
    } catch (IOException ioe) {
      System.out.println(ioe);
    }
  }
}