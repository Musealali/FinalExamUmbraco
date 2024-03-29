provider "aws" {
  region    = "eu-central-1"
  profile   = "dev"
}

terraform {
  backend "s3" {
    region  = "eu-central-1"
    profile = "dev"

    bucket  = "dmr-umbraco-terraform-state-bucket"
    key     = "dev.tfstate"
  }
}