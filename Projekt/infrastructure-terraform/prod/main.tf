//
// Key pair to use for the webserver - SSH
//
resource "aws_key_pair" "deployer" {
    key_name = "deployer-key"
    public_key = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQC4/iVKJg6j0WpQzPJcpS7ALpoFq5ZOs/GaWW+YaX2Df0FO1KD77uMxJTJhUytjBReqU8ujGqV4upeRcnPHlcnPXF1TI0A/TrSkVw2YVsXtYYxKR9YORQV/dO7CWECcwUN1tPqYCeUwO43V8V03gEnBwjV/YAeEmnaQ+nl6Aa7qwR7GIaIJEEZyWAQDoVv8EUXCiQcsIFOXx/GrH6H6yA0Itl76HkCc860YXAQKkHcKWN2yLlFVF21Dz5yhMSkuNsyHMr6x+DwBDkwgq8NyeL/J/M6uGr8ye1FLgugxWR3tXteQMbntNEr2+hbHD0rUrwCxs6seBMLYEpLZZc36QiJL ricki@LAPTOP-I9TM5L2Q"
}


//
// The production web server
//
resource "aws_instance" "webserver" {
    ami             = "ami-0bd39c806c2335b95"
    instance_type   = "t2.micro"
    key_name        = aws_key_pair.deployer.id
    user_data       = <<-EOF
                      #!/bin/bash
                      sudo su
                      yum update -y
                      yum -y install git
                      rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm
                      yum -y install dotnet-sdk-3.1

                      yum -y install httpd mod_ssl
                      cd /etc/httpd/conf.d/
                      touch webserver.conf
                      
                      echo -e "<VirtualHost *:80>" >> webserver.conf
                      echo -e "    ProxyPreserveHost On" >> webserver.conf
                      echo -e "    ProxyPass / http://127.0.0.1:5000/" >> webserver.conf
                      echo -e "    ProxyPassReverse / http://127.0.0.1:5000/" >> webserver.conf
                      echo -e "    ErrorLog /var/log/httpd/webserver-error.log" >> webserver.conf
                      echo -e "    CustomLog /var/log/httpd/webserver-access.log common" >> webserver.conf
                      echo -e "</VirtualHost>" >> webserver.conf

                      systemctl restart httpd
                      systemctl enable httpd

                      cd /
                      mkdir git
                      cd git
                      git clone https://rickifunk:Jeger3dum3@github.com/thejokerd3/FinalExamUmbraco
                      cd FinalExamUmbraco/Projekt/web-platform
                      sudo dotnet publish -c Release web-platform.csproj
                      cd bin/Release/netcoreapp3.1/
                      dotnet web-platform.dll
                      EOF 
}

output "webserver_DNS" {
    value = aws_instance.webserver.public_dns
}




