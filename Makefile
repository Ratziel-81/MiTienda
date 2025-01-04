compile_and_run_mono:
	mcs -out:Program.exe Program.cs
	mono Program.exe



docker_build:
	docker build -t apptiendav2 .

docker_exec:
	docker run -it --rm apptiendav2
