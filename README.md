# RabbitMQ Custom Metrics Service and Dasboard

## What does it do?
* Polls metrics from [RabbitMQ HTTP API](https://www.rabbitmq.com/docs/management#http-api): `/api/queues`.
* For each queue, calculates queue usage vs. `max-length` or `max-length-bytes` policy if such policy exists.
* Logs the metrics into [Grafana Loki](https://grafana.com/oss/loki/).
* Shows a time series graph for each `vhost+queue` based on the above Loki data source.


NOTE: this example can be used for any other custom metrics

## Prerequisites
* RabbitMQ
* Grafana
* Grafana Loki

![Architecture](/doc/architecture.png)

![Grafana Dashboard](/doc/dashboard.png)

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

