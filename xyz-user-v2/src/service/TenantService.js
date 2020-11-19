import Instance from "./instance";

export const AddTenant = async payload => {
  try {
    return await Instance.instance.post(`/tenant`, payload);
  } catch (error) {
    return error;
  }
};

// export const EditUser = async (payload) => {
//   try {
//     return await Instance.instance.put(`/user`, payload);
//   } catch (error) {
//     return error;
//   }
// };

export const GetAll = async payload => {
  try {
    return await Instance.instance.get(`/tenant/all`, payload);
  } catch (error) {
    return error;
  }
};

// export const GetOwnerByName = async (payload) => {
//   try {
//     return await Instance.instance.get(`/owner/list/${payload}`);
//   } catch (error) {
//     return error;
//   }
// };

// export const DeleteUser = async (payload) => {
//   try {
//     return await Instance.instance.delete(`/user/${payload}`);
//   } catch (error) {
//     return error;
//   }
// };
