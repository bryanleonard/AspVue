export const addProductToCart = ({state, commit}, product) => {
	const index = state.cart.find(
		i =>
			i.productId === product.productId &&
			i.colorId === product.colorId &&
			i.storageId === product.storageId
	);

	if (index >= 0) {
		commit("updateProductQuantity", index);
	}
	else {
		commit("addProductToCart", product);
	}
};