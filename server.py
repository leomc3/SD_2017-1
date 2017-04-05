import socket
s = socket.socket()
hot - 'localhost'
port = 12346
s.bind = ((host,port))
s.listen(5)
while True:
	c,addr = s.accept()
	print("Got connection from"),addr
	c.send("Thank you for connecting")
	while True
		print(c.recv(1024))
		c.send('msg recived\n')
