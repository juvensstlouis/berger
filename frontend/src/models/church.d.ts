interface ChurchBaseModel {
  name: string;
}

interface ChurchRequestModel extends ChurchBaseModel {
}

interface ChurchResponseModel extends ChurchBaseModel {
  id: string;
}
