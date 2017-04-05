import socket
s = sockt.socket()
host = 'localhost'
port = 12346
s.connect((host,port))
while True:
	mens = raw_input()
	c.send(mens)
	print(s.recv(1024))
