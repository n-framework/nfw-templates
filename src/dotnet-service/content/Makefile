SHELL := bash

.PHONY: format lint

format:
	dotnet format .
	dotnet csharpier format .

lint:
	dotnet format --verify-no-changes --verbosity quiet
