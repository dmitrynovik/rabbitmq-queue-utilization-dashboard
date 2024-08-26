
# Appendix

## Install .Net 8.0 SDK on Ubuntu
```
sudo apt-get update && sudo apt-get install -y dotnet-sdk-8.0
```

## Install and Start Grafana on Ubuntu
Follow [instructions](https://grafana.com/docs/grafana/latest/setup-grafana/installation/debian/)
```
sudo systemctl start grafana-server
```

## Install and Start Loki on Ubuntu
```
sudo apt-get install loki promtail

sudo systemctl start loki
sudo systemctl enable loki
sudo systemctl status loki
```

