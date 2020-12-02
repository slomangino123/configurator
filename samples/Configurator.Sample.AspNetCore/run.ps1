docker run `
-v "$(pwd)\samples\Configurator.Sample.AspNetCore\output:/output" `
-e build=false `
-e test=true `
-e branch=docker `
-e YAML_OUTPUT_PATH="/output" `
-e YAML_FILENAME="docker" `
configurator:aspnetcore