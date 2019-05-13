<template>
<b-container fluid class="page">
	<b-row>
		<b-col cols="3">
			<filters v-if="filters.brands.length" :filters="filters" />
			<!-- v-if="filters.brands.length" -->
		</b-col>
		<b-col cols="9">
			<product-list :products="products" />
		</b-col>
	</b-row>
</b-container>
</template>

<script>
import axios from "axios";
import Filters from "../components/catalog/Filters.vue";
import ProductList from '../components/catalog/ProductList.vue';

export default {
	name: 'catalog',
	components : {
		Filters,
		ProductList
	},
	data() {
		return {
			products: [],
			filters: {
				brands: [],
				capacity: [],
				colors: [],
				os: [],
				features: []
			}
		};
	},
	methods: {
		setData(products, filters) {
			this.products = products;
			this.filters = filters;
		}
	},
	// mounted() {
	// 	fetch("api/products")
	// 		.then(response => { return response.json() })
	// 		.then(products => { this.products = products });
	// }
	//old way, no longer works since we removed isomorphc-fetch
	// fetch("api/products")
	// 	.then(response => { return response.json(); })
	// 	.then(products => { next(vm => vm.setData(products)); });
	beforeRouteEnter(to, from, next){
		axios
			.all([
				axios.get("/api/products", { params: to.query }),
      			axios.get("/api/filters")
			])
			.then(
				axios.spread((products, filters) => {
        			next(vm => vm.setData(products.data, filters.data));
      			})
			);
	},
	beforeRouteUpdate(to, from, next) {
		axios.get("/api/products", { params: to.query }).then(response => {
			this.products = response.data;
			next();
		});
	}



}
</script>