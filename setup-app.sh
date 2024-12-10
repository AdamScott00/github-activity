dotnet publish -c Release -r osx-arm64 --self-contained true -o ./publish -p:PublishSingleFile=true
sudo cp ./publish/github-activity /usr/local/bin/github-activity
chmod +x /usr/local/bin/github-activity
