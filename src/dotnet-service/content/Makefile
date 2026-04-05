SHELL := bash

.PHONY: format lint test

format:
	dotnet format .
	dotnet csharpier format .

lint:
	dotnet format --verify-no-changes --verbosity quiet

test:
	dotnet test
