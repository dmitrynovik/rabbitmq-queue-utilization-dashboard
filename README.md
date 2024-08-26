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

