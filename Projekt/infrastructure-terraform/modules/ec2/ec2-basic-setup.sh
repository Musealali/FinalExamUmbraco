#!/bin/bash
sudo apt -y update
sudo apt -y install nodejs
sudo apt -y install apache2
echo "<p> My Instance! </p>" > /var/www/html/index.html