# Prerequisits

```
dotnet tool install --global dotnet-dump
dotnet tool install --global dotnet-dump
```

# Running the application

in `src\Vizor.ECharts.Demo` 

```
dotnet run -c Debug
```

# Memory profiler

Get the PID
```
Get-Process -Name "Vizor.ECharts.Demo"

Handles  NPM(K)    PM(K)      WS(K)     CPU(s)     Id  SI ProcessName
-------  ------    -----      -----     ------     --  -- -----------
    434      55    69652      52480       0.52  26216   1 Vizor.ECharts.Demo
```

Start the trace
```
dotnet-trace collect --process-id <YOUR_APP_PROCESS_ID> --providers Microsoft-DotNETCore-SampleProfiler
```

Dump the output
```
dotnet-dump collect --process-id <YOUR_APP_PROCESS_ID> --type Full

Writing full to C:\Users\Ben\dump_20230802_002152.dmp
Complete
```

Open the output file with Visual Studio