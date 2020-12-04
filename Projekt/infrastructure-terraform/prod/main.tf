//
// Key pair to use for the webserver - SSH
//
resource "aws_key_pair" "deployer" {
    key_name = "deployer-key"
    public_key = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQDSRL6iyQwfcLdUKqCYJ2tAs7fhwk6AcRLal96ecUvYYCvAr1AnbMrlAzVkyxMter5TFlTiJnHPEnVkiMd2/zs8cWmUq1fPCEEsNpZGYUCHZryB686IAiQb2WQVNQNMdlmo7Rs2s507UyIbdyptZ/gkbJgGdrdmWF0Ot9aC93Kr5xZ/6whkmSFSo1+nCTmu9QhEv+6YsBA/7PkevNd+97sJ16tjndcstQFDlr+ibPuxnHAzx5o+PvIuNIDnm/r3ZE0E93sFkek9D8rAjc+lBThDe2An1sPGNpHNHMT13mC7oJttkLOB+l3SuN9tkDCpFsk/Fu1LQx/IEJj1PazEYvOl ricki@DESKTOP-O7HU10J"
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
                      yum -y install git
                      yum -y install httpd
                      echo "<p>Webserver test</p>" >> /var/www/html/index.html
                      sudo systemctl enable httpd
                      sudo systemctl start httpd
                      EOF 
}

output "webserver_DNS" {
    value = aws_instance.webserver.public_dns
}




