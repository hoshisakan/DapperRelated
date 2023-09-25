#!/bin/bash

if [ -z "$1" ]; then
    echo "No argument supplied"
    echo "Usage: ./addPackages.sh <project> or <classlib_name>"
    exit 1
fi

# solution="DapperWithDependencyInjection"

echo "Starting add packages to projects and classlib."

# cd $solution

if [ -d "$1" ]; then
    echo "Directory $1 exists."
    cd $1
else
    echo "Directory $1 does not exist."
    exit 1
fi

if [ "$1" = "DapperWithDependencyInjection" ]; then
    dotnet add package Microsoft.Extensions.Configuration --version 7.0.0
    dotnet add package Microsoft.Extensions.DependencyInjection.Abstractions --version 7.0.0
elif [ "$1" = "DataAccess" ]; then
    dotnet add package Dapper --version 2.0.143
    # dotnet add package Microsoft.Data.SqlClient --version 3.0.0
    dotnet add package System.Data.SqlClient --version 4.8.5
elif [ "$1" = "Models" ]; then
    dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.11
    dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 7.0.11
elif [ "$1" = "Services" ]; then
    echo "Project $1 does not need packages."
elif [ "$1" = "Utilities" ]; then
    dotnet add package Microsoft.Extensions.Configuration --version 7.0.0
    dotnet add package Microsoft.Extensions.Configuration.Json --version 7.0.0
    dotnet add package System.Configuration.ConfigurationManager --version 7.0.0
    dotnet add package System.Text.Json --version 7.0.3
    dotnet add package TaskScheduler --version 2.10.1
else
    echo "Project or classlib $1 does not exist."
    exit 1
fi

dotnet list package
cd ..

echo "Finish packages to projects and classlib."