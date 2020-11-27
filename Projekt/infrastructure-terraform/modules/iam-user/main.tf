resource "aws_iam_user" "this" {
  name                 = var.name
  path                 = var.path
  tags                 = var.tags
  permissions_boundary = var.permissions_boundary
  force_destroy        = var.force_destroy
}

resource "aws_iam_access_key" "this" {
  user = aws_iam_user.this.name
}