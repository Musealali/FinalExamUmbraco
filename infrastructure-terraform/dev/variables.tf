variable "region" {
    description = "AWS region"
    type = string
    default = "eu-central-1"
}

variable "env_prefix" {
    description = "Your environment prefix, qa, prod, dev"
    type = string
}