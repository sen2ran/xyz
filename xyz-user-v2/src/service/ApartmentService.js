import Instance from "./instance";

export const AddApartment = async (payload) => {
  try {
    return await Instance.instance.post(`/apartment`, payload);
  } catch (error) {
    return error;
  }
};

export const EditApartment = async (payload) => {
  try {
    return await Instance.instance.put(`/apartment`, payload);
  } catch (error) {
    return error;
  }
};

export const GetAll = async (payload) => {
  try {
    return await Instance.instance.get(`/apartment/all`, payload);
  } catch (error) {
    return error;
  }
};

export const DeleteApartment = async (payload) => {
  try {
    return await Instance.instance.delete(`/user/${payload}`);
  } catch (error) {
    return error;
  }
};

export const GetAllUnit = async (payload) => {
  try {
    return await Instance.instance.get(`/apartment/single/${payload}`);
  } catch (error) {
    return error;
  }
};

export const AddUnit = async (payload) => {
  try {
    return await Instance.instance.post(
      `/apartment/single/${payload.apartmentId}`,
      payload
    );
  } catch (error) {
    return error;
  }
};
