.PHONY: run format echo docker-build docker-run

run:
	@PORT=3000 dotnet run

format:
	@dotnet tool run dotnet-format -f .

echo:
	@echo "hello, world" | nc -4u -w0 localhost 3000

docker-build:
	@docker build -t udpgateway .

docker-run:
	@docker run -p 3000:3000 --env PORT=3000 udpgateway:latest

