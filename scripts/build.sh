#!/usr/bin/env bash
set -euo pipefail

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
PROJECT_ROOT="$(cd "${SCRIPT_DIR}/.." && pwd)"

source "${PROJECT_ROOT}/packages/acore-scripts/src/logger.sh"

TEMPLATES_DIR="${PROJECT_ROOT}/src"

for template in "${TEMPLATES_DIR}"/*/content; do
	[ -d "$template" ] || continue
	template_name="$(basename "$(dirname "$template")")"
	acore_log_info "Building ${template_name}..."

	if [ -f "${template}/Makefile" ]; then
		cd "$template"
		make build 2>/dev/null || acore_log_warning "No build target in ${template_name}"
	else
		acore_log_info "No Makefile in ${template_name}, skipping"
	fi
done

acore_log_success "✅ Build complete!"
