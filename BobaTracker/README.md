# Deploying

1. Publish the application with the dotnet CLI `dotnet publish --runtime linux-arm --self-contained -o ./publish` [ docs ]( https://learn.microsoft.com/en-us/dotnet/iot/deployment )
2. Send newly created publish folder via scp `scp -r publish [username]@[address]:<path to save location>`
3. Give premissions for BobaTracker in publish folder `chmod +x <path to BobaTracker>`
