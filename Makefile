SHELL := bash

.PHONY: setup format lint build test help

setup:
	./scripts/setup.sh

format:
	./scripts/format.sh

lint:
	./scripts/lint.sh

build:
	./scripts/build.sh

test:
	./scripts/test.sh

help:
	@echo "Available targets:"
	@echo "  make setup  - Initialize submodules"
	@echo "  make format - Format code"
	@echo "  make lint   - Run linter"
	@echo "  make build  - Build project"
	@echo "  make test   - Run tests"
	@echo "  make help   - Show this help message"
