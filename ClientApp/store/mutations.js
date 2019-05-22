export const addProductToCart = (state, product) => {
	product.quantity = 1;
	state.cart.push(product);
};

export const updateProductQuantity = (state, product) => {

	
	const index = state.cart.indexOf(product);

	let cartItem = state.cart[index];
	cartItem.quantity++;
  
	state.cart.splice(index, 1, Object.assign({}, cartItem));
};

/*
	This mutation is a simple case of calling the Array.splice function and passing it the 
	index argument as the position to start deleting from, and instructing it to only delete 
	a single item by passing 1 as the second parameter. 
	By modifying the cart array using the splice function, Vue can detect the change and react to it (refresh UI).
*/
export const removeProductFromCart = (state, index) => {
	state.cart.splice(index, 1);
};

export const setProductQuantity = (state, payload) => {
	const index = state.cart.indexOf(payload.product);
	let cartItem = state.cart[index];
	cartItem.quantity = payload.quantity;
  
	state.cart.splice(index, 1, Object.assign({}, cartItem));
};

export const initialize = (state, payload) => {
	Object.assign(state, payload); // create a state change so that Vue will react
  };

export const showAuthModal = state => {
	state.showAuthModal = true;
};

export const hideAuthModal = state => {
	state.showAuthModal = false;
};

export const loginRequest = state => {
	state.loading = true;
};

export const loginSuccess = (state, payload) => {
	state.auth = payload;
	state.loading = false;
};

export const loginError = state => {
	state.loading = false;
};

export const registerRequest = state => {
	state.loading = true;
};

export const registerSuccess = state => {
	state.loading = false;
};

export const registerError = state => {
	state.loading = false;
};

export const logout = state => {
	state.auth = null;
};


export const clearCartItems = state => {
	state.cart = [];
}