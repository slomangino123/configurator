docker run `
-v "$(pwd)\samples\Configurator.Sample.AspNetCore\output:/output" `
-e build=true `
-e branch=from-docker-file `
-e test=derp `
-e YAML_OUTPUT_PATH="/output" `
-e YAML_FILENAME="test" `
configurator:aspnetcore