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
    ami             = "ami-0502e817a62226e03"
    instance_type   = "t2.micro"
    key_name        = "desktop-pc"
    user_data       = <<-EOF
                      #!/bin/bash
                      sudo apt update
                      sudo apt install docker.io
                      sudo docker login -u muslimalali -p 59e41b78-3d9f-4fa7-92ae-a2425ec4bd1d
                      sudo docker pull muslimalali/finaleexameumbraco
                      sudo docker logout

                      sudo docker run --rm -p 80:80 -p 443:443 muslimalali/finaleexameumbraco
                      EOF 
}

output "webserver_DNS" {
    value = aws_instance.webserver.public_dns
}




