export const addProductToCart = ({state, commit}, product) => {
	const exists = state.cart.find(
		i =>
			i.productId === product.productId &&
			i.colorId === product.colorId &&
			i.storageId === product.storageId
	);

	if (exists) {
		commit("updateProductQuantity", product);
	}
	else {
		commit("addProductToCart", product);
	}
};

export const removeProductFromCart = ({ commit }, product) => {
  commit("removeProductFromCart", product);
};
