//===== VPC =====//
resource "aws_vpc" "this" {
    cidr_block = var.vpc_cidr
    instance_tenancy = "default"

    tags = {
        Name = "${var.env_prefix}-vpc"
    }
}

resource "aws_internet_gateway" "this" {
    vpc_id = aws_vpc.this.id

    tags = {
        Name = "${var.env_prefix}-ig"
    }
}


//===== PUBLIC SUBNET =====//
resource "aws_subnet" "public" {
  vpc_id     = aws_vpc.this.id
  cidr_block = var.public_subnet_cidr
  availability_zone = "eu-central-1a"
  tags = {
    Name = "${var.env_prefix}-public"
  }
}

resource "aws_route_table" "public" {
    vpc_id = aws_vpc.this.id

    route {
        cidr_block = "0.0.0.0/0"
        gateway_id = aws_internet_gateway.this.id
    }

    tags = {
        Name = "${var.env_prefix}-public"
    }
}

resource "aws_route_table_association" "public" {
    subnet_id = aws_subnet.public.id
    route_table_id = aws_route_table.public.id
}