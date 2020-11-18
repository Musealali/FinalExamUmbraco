module "web-server" {
    source = "./modules/ec2"
    vpc_id = module.vpc_network.vpc_id
    subnet_public_id = module.vpc_network.subnet_public_id
    user_data = file("./modules/ec2/ec2-basic-setup.sh")
    env_prefix = var.env_prefix
}