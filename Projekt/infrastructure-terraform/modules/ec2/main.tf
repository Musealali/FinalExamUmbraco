//===== SECURITY GROUPS FOR VPC =====//
// TCP / 80 / 443
resource "aws_security_group" "web" {
    name = "${var.env_prefix}-vpc_web"
    description = "Allow incoming HTTP connections."
    vpc_id = var.vpc_id

    ingress {
        from_port = 80
        to_port = 80
        protocol = "tcp"
        cidr_blocks = ["0.0.0.0/0"]
    }
    ingress {
        from_port = 443
        to_port = 443
        protocol = "tcp"
        cidr_blocks = ["0.0.0.0/0"]
    }
    ingress {
        from_port = -1
        to_port = -1
        protocol = "icmp"
        cidr_blocks = ["0.0.0.0/0"]
    }
}

// SSH
resource "aws_security_group" "ssh" {
    name = "${var.env_prefix}-vpc_ssh"
    description = "Allow incoming SSH connections"
    vpc_id = var.vpc_id

    ingress {
        from_port = 22
        to_port = 22
        protocol = "tcp"
        cidr_blocks = ["0.0.0.0/0"]
    }
}

// OUTBOUND
resource "aws_security_group" "outbound" {
    name = "${var.env_prefix}-vpc_outbound"
    description = "Allow all outbound traffic"
    vpc_id = var.vpc_id

    egress {
        from_port = 0
        to_port = 0
        protocol = "-1"
        cidr_blocks = ["0.0.0.0/0"]
    }
}



//===== AWS WEB EC2 =====//
resource "aws_instance" "web" {
    ami = "ami-04932daa2567651e7"
    availability_zone = "eu-central-1a"
    instance_type = "t2.micro"

    vpc_security_group_ids = [
        aws_security_group.web.id,
        aws_security_group.ssh.id,
        aws_security_group.outbound.id
    ]
    
    subnet_id = var.subnet_public_id
    associate_public_ip_address = true
    source_dest_check = false

    tags = {
        Name = "${var.env_prefix}"
    }

    user_data = var.user_data  
}