variable "vpc_id" {
    description = "The id of an vpc resource, that this EC2 instance is associated with"
    type = string
}

variable "subnet_public_id" {
    description = "The id of the public subnet"
    type = string
}

variable "user_data" {
    description = "The user data required for this EC2 instance"
    type = string
}

variable "env_prefix" {}