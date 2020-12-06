docker run `
-v "$(pwd)\samples\Configurator.Sample.AspNetCore\output:/app/output" `
-e build=false `
-e test=true `
-e branch=docker `
-e YAML_OUTPUT_PATH="/app/output" `
-e YAML_FILENAME="docker" `
configurator:aspnetcore

# Environment variables will override appsettings.