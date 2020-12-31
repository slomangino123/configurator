# Configurator

Configurator is a free, open-source tool used to configure CI/CD pipelines by injesting input arguments and producing custom environment configuration in an easy, reliable, testable and easily containerized way.

## Build Status
![.NET Core](https://github.com/slomangino123/configurator/workflows/.NET%20Core/badge.svg?branch=master)
 
## Quickstart
### Install Packages
```
install-package Configurator.Core
install-package Configurator.AspNetCore
```
### Arguments
Following package installation create a implementation of `IArguments` that will define input arguments. This example there are 4 simple arguments.
- Build - boolean
- Test - boolean
- Branch - string
- Confirmation - boolean

```
public class Arguments : IArguments
{
    public Arguments(...)
    {
        ...
    }

    public bool Build { get; private set; }
    public bool Test { get; private set; }
    public string Branch { get; private set; }
    public bool Confirmation { get; private set; }
}
```

Create an implementation of `IArgumentExtractor<>` to get the arguments from `IConfiguration` into the `IArgument` implementation. `IArgumentExtractor` defines one method and it is used to extract arguments from IConfiguration.
- `Extract` is used, well, to extract... 

__Example:__
```
public class ArgumentExtractor : IArgumentExtractor<Arguments>
{
    public const string BUILD = "build";
    public const string TEST = "test";
    public const string BRANCH = "branch";
    public const string CONFIRMATION = "confirmation";

    public Arguments Extract(IConfiguration config)
    {
        var build = TryParseBool(config, BUILD);
        var test = TryParseBool(config, TEST);
        var branch = config[BRANCH];
        var confirmation = TryParseBool(config, CONFIRMATION);
        var args = new Arguments(build, test, branch, confirmation);
        return args;
    }

    private bool TryParseBool(IConfiguration config, string key)
    {
        if (!bool.TryParse(config[key], out bool value))
        {
            throw new ArgumentException($"Could not parse boolean value for {key}: \"{config[key]}\".");
        }
        return value;
    }
}
```

### Output
Create a class that will define your pipeline configuration output, what you will use to control your CI/CD.

```
public class Output : IOutput
{
    public Output() { }

    public bool Build { get; set; }
    public bool Test { get; set; }
    public Git Git { get; set; }
    public bool Confirmation { get; set; }
}
```

### Output Processors
Output Processors are what convert some or all of the `IArguments` implementation into sections of the `IOutput` implementation. A processor is a subclass of `BaseOutputProcessor<TProperty, TOutput, TArguments>` which requires two abstract members to be implemented.
- `OutputPropertySelector` is used to define which property of `IOutput` will be set using this processor.
- `Process` is to calculate that value using the `IArguments` implementation.

__Example:__
```
public class BuildProcessor : BaseOutputProcessor<bool, Output, Arguments>
{
    public override Expression<Func<Output, bool>> OutputPropertySelector => (x) => x.Build;

    public override bool Process(Arguments arguments)
    {
        return arguments.Build || arguments.Test;
    }
}
```

### Configuring Configurator
Add Configurator using `PipelineConfigurationExtensions.AddConfigurator()`. This will return a IPipelineBuilder which will allow chaining of configurations in a fluent manner.
```
var builder = PiplineConfigurationExtensions.AddConfigurator<Arguments, Output>()

// Add Environment Variable configuration
.AddEnvironmentVariableArguments()

// Add Json file configuration
.AddJsonFileArguments("appsettings.json")

// Add BuildProcessor to the pipeline
.AddProcessor<BuildProcessor>()

// Add some ways to display the output
// Console
.AddConsoleGenerator()

// .yaml file generator
.AddYamlGenerator();

// Build the pipeline executor
var executor = builder.Build();

// Execute the pipeline and run Configurator
executor.Execute();
```

### Running the samples
#### Docker
Use the [sample powershell scripts](https://github.com/slomangino123/configurator/tree/master/samples/Configurator.Sample.AspNetCore) as a base for how to build and run the sample project in docker.
- `build.ps1` Build the dockerfile
- `run-env.ps1` Run the docker image, uses environment variables for configuration
- `run-appsettings.ps1` Run the docker image, uses the appsettings.json file for configuration

Both scripts use `-v` to mount an output directory so that any output files are persisted to the local machine.

#### Visual Studio
Use Visual Studio debugging to run the sample project, there are no environment variables configured, only appsettings.

## Full Documentation
[Coming Soon...](https://github.com/slomangino123/configurator)

## Contributing
[Coming Soon...](https://github.com/slomangino123/configurator)
 
