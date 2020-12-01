docker run `
-v "$(pwd)\samples\Configurator.Sample.AspNetCore\output:/output" `
-e build=true `
-e branch=docker `
-e test=derp `
-e YAML_OUTPUT_PATH="/output" `
-e YAML_FILENAME="docker" `
configurator:aspnetcore