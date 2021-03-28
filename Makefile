dummy:
	cat Makefile

linux:
	rm -f ./release.linux/*
	dotnet publish -o release.linux -c Release

win:
	rm -f ./release.win/*
	dotnet publish -o release.win -c Release
