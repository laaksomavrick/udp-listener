.PHONY: run echo docker-build

run:
	@PORT=3000 dotnet run --project UdpGateway
    
echo:
	@echo "hello, world" | nc -4u -w0 localhost 3000
	
docker-build:
	@docker build -t udpgateway .
	
docker-run:
    @docker run -p 3000:3000 --env PORT=3000 updgateway:latest
