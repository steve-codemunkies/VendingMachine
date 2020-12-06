# VendingMachine Kata

## Development

This kata has been developed in C# on dotnet using [VS Code](https://code.visualstudio.com/). The project makes use of [development containers](https://code.visualstudio.com/docs/remote/containers).

**N.B.** It is not necessary to use VS Code _or_ Dev Containers to modify or run this kata. All that is required is the [.NET Core SDK](https://dotnet.microsoft.com/download/visual-studio-sdks).

## Running the tests

If you are using VS Code and Dev Containers then the [.NET Core Test Explorer](https://marketplace.visualstudio.com/items?itemName=formulahendry.dotnet-test-explorer) is [automatically installed](https://github.com/steve-codemunkies/VendingMachine/blob/5ddd8508c5cd096efca9b028bcffb46f0fb11e3b/.devcontainer/devcontainer.json#L22). 

To run the tests from the command line go to the root of the repository and run `dotnet test`.

# Decisions

## Weights, diameters and values represented as integers

In a real system these values would probably be represented using [`System.Decimal`](https://docs.microsoft.com/en-us/dotnet/api/system.decimal?redirectedfrom=MSDN&view=netcore-3.1). As noted in the [remarks](https://docs.microsoft.com/en-us/dotnet/api/system.decimal?redirectedfrom=MSDN&view=netcore-3.1#remarks) it is still necessary to correctly round the result of any caluculation, which also puts comparisons in doubt. To simplify the kata by reducing the number of randomly failing tests I have decided to represent these values as `int`.

## Vending machines use generic containers, and details of prices and quantities are configured

When loading a vending machine the operator does not swap in a new chocolate bar, crisp or drink container, instead the existing container is reconfigured in the vending machine. On this basis a single configurable container will be used in this kata. 

# Assumptions

## Coins of a given weight and diameter can only have one value

The only way for the vending machine to distinguish coins is via their weight and diameter. However it is possible for coins of multiple specification to represent the same value (e.g. the round pound coin and 12 sided coin were both in circulation and legal tender from early 2017 until October 2017).