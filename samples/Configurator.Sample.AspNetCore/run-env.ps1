docker run `
-v "$(pwd)\output:/app/output" `
-e build=false `
-e test=true `
-e branch=docker `
-e confirmation=true `
-e YAML_OUTPUT_PATH="/app/output" `
-e YAML_FILENAME="docker" `
configurator:aspnetcore

# Environment variables will override appsettings.