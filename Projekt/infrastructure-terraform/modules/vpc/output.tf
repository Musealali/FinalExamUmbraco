output "vpc_id" {
    value = aws_vpc.this.id
}

output "subnet_public_id" {
    value = aws_subnet.public.id
}